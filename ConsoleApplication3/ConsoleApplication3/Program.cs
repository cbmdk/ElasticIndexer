using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using Nest;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ConsoleApplication3
{
    class Program
    {
        private const int BulkSize = 5000;
        private const string DefaultIndex = "dialog";
        
        static void Main(string[] args)
        {
            try
            {
                DataContextDataContext db = new DataContextDataContext();
                
                var client = CreateElasticClient();

                CreateIndexForTable(client, db.case_histories);
                //  CreateIndexForTable(client,db.events);
                CreateIndexForTable(client, db.case_user_views);
                CreateIndexForTable(client, db.case_comments);
                CreateIndexForTable(client, db.time_registrations);
                CreateIndexForTable(client, db.cases);
                CreateIndexForTable(client, db.CaseLogs);
                CreateIndexForTable(client, db.changelog_items);
                CreateIndexForTable(client, db.files);
                CreateIndexForTable(client, db.change_revisions);
                CreateIndexForTable(client, db.change_revision_reviews);
                CreateIndexForTable(client, db.builds);
                CreateIndexForTable(client, db.milestone_cases);
                CreateIndexForTable(client, db.case_transfers);
                CreateIndexForTable(client, db.UserStats);
                CreateIndexForTable(client, db.release_cases);
                CreateIndexForTable(client, db.releases);
                CreateIndexForTable(client, db.TaskLogs);
                CreateIndexForTable(client, db.users);
                CreateIndexForTable(client, db.invoices);
                CreateIndexForTable(client, db.casesClientNets);
                CreateIndexForTable(client, db.milestones);
                CreateIndexForTable(client, db.projects);
                CreateIndexForTable(client, db.user_role_links);
                CreateIndexForTable(client, db.CaseStats);
                CreateIndexForTable(client, db.Computers);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Done inserting");
            Console.ReadLine();
        }
        
        private static IElasticClient CreateElasticClient()
        {
            var connectionSettings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .SetDefaultIndex(DefaultIndex)
                .SetConnectTimeout(1000)
                .SetPingTimeout(200)
                .SetJsonSerializerSettingsModifier(settings =>
                {
                    settings.Converters.Add(new StringEnumConverter());
                    settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            var client = new ElasticClient(connectionSettings);

            return client;
        }

        private static void CreateIndexForTable<T>(IElasticClient client, Table<T> db) where T : class
        {
            client.CreateIndex((indexDescriptor => IndexMapping.CreateIndexDescriptorForTable(indexDescriptor, DefaultIndex, db)));
            var listOfItems = new List<T>(BulkSize);
            var stopWatch = Stopwatch.StartNew();
            var count = 0;
            foreach (var source in db.ToList())
            {
                count++;
                listOfItems.Add(source);
                if (listOfItems.Count == BulkSize)
                {
                    IndexTable(client, listOfItems);
                    Console.WriteLine("indexed {0} {2} in {1}", count, stopWatch.Elapsed.Humanize(5),db.ToString());
                    listOfItems.Clear();
                }
            }
            IndexTable(client, listOfItems);
            Console.WriteLine("indexed {0} {2} in {1}", count, stopWatch.Elapsed.Humanize(5), db.ToString());
            count = 0;
        }

        private static BulkDescriptor CreateBulkDescriptor<T>(IEnumerable<T> table) where T: class
        {
            return new BulkDescriptor()
                .IndexMany(table, (descriptor, thisTable) => descriptor.Document(thisTable));
        }
        
        private static void IndexTable<T>(IElasticClient client, List<T> table) where T : class
        {
            var bulkDescriptor = CreateBulkDescriptor(table);
            var response = client.Bulk(bulkDescriptor);

            if (!response.IsValid)
            {
                if (response.ServerError != null)
                {
                    Console.WriteLine(response.ServerError.Error);
                }

                foreach (var item in response.ItemsWithErrors)
                {
                    Console.WriteLine(item.Error);
                }
            }
        }
    }
}
