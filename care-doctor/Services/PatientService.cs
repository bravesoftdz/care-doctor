using System;
using System.Linq;
using Couchbase.Lite;
using caredoctor.Models;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Couchbase.Lite.Query;

namespace caredoctor.Services
{
    public class PatientService
    {
        Database pat_database;
        HttpClient client;

        public PatientService()
        {
            // Get the database (and create it if it doesn't exist)
            pat_database = new Database(Constants.PATIENT_DATABASE);
            client = new HttpClient();

            //// Create a new document (i.e. a record) in the database
            //string id = null;
            //id = "kabilan@test.com";
            //using (var mutableDoc = new MutableDocument(id))
            //{
            //    mutableDoc.SetFloat("version", 2.0f)
            //        .SetString("type", "SDK");

            //    // Save it to the database
            //    pat_database.Save(mutableDoc);
            //}

            //// Update a document
            //using (var doc = pat_database.GetDocument(id))
            //using (var mutableDoc = doc.ToMutable())
            //{
            //    mutableDoc.SetString("language", "C#");
            //    pat_database.Save(mutableDoc);

            //    using (var docAgain = pat_database.GetDocument(id))
            //    {
            //        Console.WriteLine($"Document ID :: {docAgain.Id}");
            //        Console.WriteLine($"Learning {docAgain.GetString("language")}");
            //    }
            //}

            //// Create a query to fetch documents of type SDK
            //// i.e. SELECT * FROM database WHERE type = "SDK"
            //using (var query = QueryBuilder.Select(SelectResult.All())
            //    .From(DataSource.Database(pat_database))
            //    .Where(Expression.Property("type").EqualTo(Expression.String("SDK"))))
            //{
            //    // Run the query
            //    var result = query.Execute();
            //    Console.WriteLine($"Number of rows :: {result.Count()}");
            //}

            // Create replicator to push and pull changes to and from the cloud
            //var targetEndpoint = new URLEndpoint(new Uri(Constants.REPLICATOR_URL));
            //var replConfig = new ReplicatorConfiguration(pat_database, targetEndpoint);

            //// Add authentication
            //replConfig.Authenticator = new BasicAuthenticator(Constants.SYNC_GATEWAY_USERNAME, Constants.SYNC_GATEWAY_PASSWORD);

            //// Create replicator
            //var replicator = new Replicator(replConfig);
            //replicator.AddChangeListener((senders, args) =>
            //{
            //    if (args.Status.Error != null)
            //    {
            //        Console.WriteLine($"Error :: {args.Status.Error}");
            //    }
            //});

            //replicator.Start();
        }

        public void CreatePatient(PatientModel _patient_model)
        {
            try
            {
                using (var pat_mutable_doc = new MutableDocument(_patient_model.mobile))
                {
                    pat_mutable_doc.SetString("name", _patient_model.name).SetString("mobile", _patient_model.mobile).SetString("dob", _patient_model.dob).SetString("gender", _patient_model.gender);
                    pat_database.Save(pat_mutable_doc);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public async Task<HttpResponseMessage> AddPatientListToDoctorAsync(LoginModel _login_model)
        {
            var uri = new Uri(string.Format(Constants.UPDATE_PATIENT_LIST_URL));
            string jsonData = JsonConvert.SerializeObject(_login_model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            return await client.PostAsync(uri, content);
        }

        public void GetAllPatients(PatientModel _patient_model)
        {
            try
            {
                //var query = "SELECT fname, email FROM test WHERE type = 'user' and age=25";
                //var result = bucket.Query<dynamic>(query);

                using (var query = QueryBuilder.Select(SelectResult.All())
                .From(DataSource.Database(pat_database)))
                {
                    // Run the query
                    foreach (var result in query.Execute())
                    {
                        Console.WriteLine(result.GetString(0));
                        Console.WriteLine(result.GetString("id"));
                        Console.WriteLine($"Document id {result.Keys.Equals("name")}");
                        Console.WriteLine($"Document count :: {result.GetValue("patients")}");
                        Console.WriteLine($"Document id {result.GetString(0)}");
                        Console.WriteLine($"Document count :: {result.Keys}");
                        Console.WriteLine($"Document Mobile :: {result.GetDictionary("id")}");
                        Console.WriteLine($"Document Name :: {result.GetString("patients")}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
