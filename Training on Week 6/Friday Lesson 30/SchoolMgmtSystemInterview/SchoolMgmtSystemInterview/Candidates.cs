using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmtSystemInterview
{
    class Candidates
    {
        public string candidate_Id { get; set; }
        public string candidate_name { get; set; }

        public double yearsOfExperience { get; set; }

        public bool candidate_degree { get; set; }

        public int candidate_finalscore { get; set; }

        public Candidates(string id, string name, double years, bool degree, int score)
        {
            candidate_Id = id;
            candidate_name = name;
            yearsOfExperience = years;
            candidate_degree = degree;
            candidate_finalscore = score;
        }
    }
}
