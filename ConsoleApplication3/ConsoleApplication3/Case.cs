using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class CaseModel
    {
        [Key]
        public int Id { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime Response_Date { get; set; }
        public int created_by_userid { get; set; }
        public int assigned_to_userid { get; set; }
        public int responsible_userid { get; set; }
        public int customer_userid { get; set; }
        public int customer_id { get; set; }
        public int project_id { get; set; }
        public int estimated_hours { get; set; }
        public int estimated_userid { get; set; }
        public string Description { get; set; }
        public string reference { get; set; }
        public string notes { get; set; }

        public int isinvoicable { get; set; }
        public int part_of_contract { get; set; }
        public int rating { get; set; }
        public int layer { get; set; }
        public int verified_by_developer { get; set; }
        public int estimate_accepted { get; set; }
        public int stateid { get; set; }
        public int releasePlanid { get; set; }
        public int productid { get; set; }
        public int Versionid { get; set; }
        public int EnvironmentId { get; set; }
        public int sReleaseId { get; set; }
        public int estimated_delivery_hours { get; set; }
        public int estimated_delivery_userid { get; set; }
        public int branch_id { get; set; }
        public int identified_branch_id { get; set; }
        public int specification_accepted { get; set; }
        public int roadmap_new_report { get; set; }
        public bool feedback_required { get; set; }
        public bool checklist { get; set; }
        public string release_solution { get; set; }
        public string test_flow { get; set; }
        public DateTime releaseDate { get; set; }
        public bool estimate_released { get; set; }
        public string estimate_text { get; set; }
        public bool isClientNetCase { get; set; }
        public bool isupdated { get; set; }
        public bool solution_confirmed { get; set; }
        public string DescriptionHTML { get; set; }
        public bool threshold { get; set; }
        public string public_summary { get; set; }
        public string shortname {get; set;}
        public string technical_summary { get; set; }
        public bool breaking_change { get; set; }
        public bool estimation_finalized { get; set; }
        public bool exclude_case { get; set; }
        public decimal dev_estimate { get; set; }
    }
}


