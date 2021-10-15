using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmtSystemInterview
{
    class Interview
    {
        public static Dictionary<string, Candidates> dictionaryOfCandidates = new Dictionary<string, Candidates>();

        public static void InterviewProcess()
        {
            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine("1: Interview math teacher");
                    Console.WriteLine("2: Interview english teacher");
                    Console.WriteLine("3: See current highest score candidate");
                    int input = Int32.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            {

                                Console.WriteLine("Key in candidate years of experience in teaching");
                                double years = double.Parse(Console.ReadLine());
                                if (years < 3)
                                {
                                    Console.WriteLine("Sorry need more teaching experience");
                                    SentOff();
                                    loop = false;
                                    break;
                                }
                                Console.WriteLine("Key in candidate math degree relevancy, if true or false");
                                bool input1 = bool.Parse(Console.ReadLine());
                                if (input1 == false)
                                {
                                    Console.WriteLine("Sorry no relevant degree, rejected");
                                    SentOff();
                                    loop = false;
                                    break;
                                }

                                Console.WriteLine("Key in candidate name");
                                string name = Console.ReadLine();

                                Console.WriteLine("create new candidate id");
                                string id = Console.ReadLine();

                                if (dictionaryOfCandidates.ContainsKey(id))
                                {
                                    Console.WriteLine("Account already exists");
                                }
                                else
                                {
                                    var new_user = new Candidates(id, name, years, input1, 0);
                                    dictionaryOfCandidates.Add(new_user.candidate_Id, new_user);
                                }
                                break;
                            }
                        case 2:
                            {

                                Console.WriteLine("Key in candidate years of experience in teaching");
                                double years = double.Parse(Console.ReadLine());
                                if (years < 3)
                                {
                                    Console.WriteLine("Sorry no chance");
                                    SentOff();
                                    loop = false;
                                    break;
                                }
                                Console.WriteLine("Key in candidate english degree relevancy, if true or false");
                                bool input2 = bool.Parse(Console.ReadLine());
                                if (input2 == false)
                                {
                                    Console.WriteLine("Sorry no chance");
                                    SentOff();
                                    loop = false;
                                    break;
                                }

                                Console.WriteLine("Key in candidate name");
                                string name = Console.ReadLine();

                                Console.WriteLine("create new candidate id");
                                string id = Console.ReadLine();

                                if (dictionaryOfCandidates.ContainsKey(id))
                                {
                                    Console.WriteLine("Account already exists");
                                }
                                else
                                {
                                    var new_user = new Candidates(id, name, years, input2, 0);
                                    dictionaryOfCandidates.Add(new_user.candidate_Id, new_user);
                                    InterviewProcess2();
                                }
                                break;
                            }
                        case 3:
                            {
                                InterviewProcess2();
                                break;
                            }
                        default:
                            {
                                loop = false;
                                break;
                            }
                    }
                }
                catch
                {
                    Console.WriteLine("some error occured, continue");
                }
                finally
                {

                }
                ListAllUsers();
                Console.WriteLine("Exiting the program");
            }          
        }
        public static void ListAllUsers()
        {
            foreach (var item in dictionaryOfCandidates)
            {
                Console.WriteLine("{0} > {1} > {2} > {3}", item.Key, item.Value.candidate_name, item.Value.yearsOfExperience, item.Value.candidate_degree);
            }
            Console.WriteLine(" Viewing all selected candidates here");
        }

        public static void SentOff()
        {
            Console.WriteLine("Sorry you have not been chosen");
        }

        public static void InterviewProcess2()
        {
            Console.WriteLine("Find first stage success candidates by ID");
            string user_id = Console.ReadLine();

            if (dictionaryOfCandidates.ContainsKey(user_id))
            {
                Console.WriteLine("Key in math degree score 0 to 100");
                int mathscore = Int32.Parse(Console.ReadLine());

                int interviewscore = mathscore / 20;

                Console.WriteLine("Current in years of experience: " + dictionaryOfCandidates[user_id].yearsOfExperience);
                string Stryears = dictionaryOfCandidates[user_id].yearsOfExperience.ToString();

                int year = Int32.Parse(Stryears);

                int interviewscore2 = year;

                int finalscore = interviewscore + interviewscore2;
                // interview final score is based on exam marks + years of experience pro-rated

                dictionaryOfCandidates[user_id].candidate_finalscore = finalscore;
                MostSuitableCandidate();
            }
            
        }

        public static void MostSuitableCandidate()
        {
            foreach (var item in dictionaryOfCandidates)
            {
                Console.WriteLine("{0} > {1} > {2} > {3} > {4}", item.Key, item.Value.candidate_name, item.Value.yearsOfExperience, item.Value.candidate_degree, item.Value.candidate_finalscore);
                string str = item.Value.candidate_finalscore.ToString();

                int score = Int32.Parse(str);

                if (score > 8 && score < 20)
                {
                    Console.WriteLine("");
                    Console.WriteLine(item.Value.candidate_name + " has been chosen and selected");
                    dictionaryOfCandidates[item.Key].candidate_finalscore = 100;
                    break;

                }
                if (score < 8)
                {
                    dictionaryOfCandidates.Remove(item.Key);
                    Console.WriteLine(item.Value.candidate_name + " has been removed as score is not up to standard");
                    break;
                }
            }
            Console.WriteLine("");
            Console.WriteLine(" Viewing all selected candidates here");
        }
    }
}
