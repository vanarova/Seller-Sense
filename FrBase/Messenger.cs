using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using DeviceId;
using System.Text;
using System.Threading.Tasks;

namespace FrBase
{
    public class Messenger
    {

        //private class FirebaseHelper
        //{
            private static FirestoreDb firestoreDb;
            public Messenger()
            {
                //firestoreDb = GetFirebaseDatabaseRef();
            }
            private static void GetFirebaseDatabaseRef()
            {
                //string jsonKey = @"{ ""type"": ""service_account"",  ""project_id"": ""seller - sense - license"",  ""private_key_id"": ""6c9c50e996205ae44546b9c6e6642547e212f47e"",  ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDKSs17zg+Cz2cA\nBYLmlMACHgQzx9ypVp42xWVIn+zwtlAHy9xGg6U/theM0oXavUGFhbbdc7hkJOuH\nP5pZ6uqAVYV5jNkE2Vym2erUDKmRdFfPI1Bioe3DPDrOJmKfL8LZAjy+69Ywml32\nWpn3x5An1+TGwlb+yrew+IJ0byWoKk40g5kZkJUAYnQ08kQZjIUaqiYcZb6JtG5H\nINgf0OOvSVXTEVk3OutGV8admhHximL2jyIp2XoOnAZhaPzfRs3h2e701SztHNZQ\n55Bd3tDBzywORx1FrDFKZEclFOiv7gPcdp5yEt5qJMJObF6KGX4r4QAGNgcAx9Oe\nXb1khvaRAgMBAAECggEAB//uKTcmdYElkOp24S7Y2sCUgJZ21UbC0BZNbYI/Cswf\n5TYIcIyuU1Mccm4FG3fMZHcLqq1jyWiNHKKtFEEaK8/t/Mb/Uk30+DdyDheP2Vvj\nKNKsADGIgzXxmqNJl0Nako3ASJnPlSmWnYpa0EHW4196GWrYKUBrpBrIwGlgkSpE\nmXCpX+9feahNdjb624NI4nhCtmdklNTe+Nkw7DGy2q2QleydDxp1rAPg2qKvyW+e\n3G+uXsJnSZb4eXwA7eWGnIUTWSnMX9SfNeQo3ka2NlRqDxO404JZTwKgh4ptHxu4\n4eHXsDEO3Ob3PR6Coz6TR2CB5Gwno5tKm1mLA/lZ4QKBgQDwqu+UqVoSd08/9ESv\nd0ZdkfkqgbEkRBtXkjZ0ogboStN0w9arsneYAj2gGburqQ9uInYL65WGsQCw1NTM\nDL6X7x4f69FhN64rtjzgQ5W59GCG/7XRl8QXt9m8c140xCju8IA3k1PjQaxW0A+s\njDCTQqya/QEPFYQfgasefwHnsQKBgQDXLf+HspwsSZhxZnjprPvHb30gD8VaXyL7\nlT9cGb8WRzllK0l4q3nG4ALTxOpwhOd1aANNCJJJ7qw/5x9wMRW+2vDQ2F1mzqoC\nT5vaEiQMeE+I40Aqb7o/h3jc5byWt21X+zH55AAG2T5ByfBvRGwHp1jz5k2QZ8e5\nHHExqmiU4QKBgGfsqIA9kROgSayIQpCypMQLINlmH6RVdKkgDjvXK7xrc1xcpPqH\nmnUdopbcBdpeqrcYUnlbRbpf/Lhfb3SdnD/nlc6a+lNMw/1EOI1vIdym1nf1PAJB\n0v+a+H8UIn4Ops5nNDbLe9IKreze86XC88bjZ72VuztUQzWHvOjyV1RBAoGAat9X\nuOgHFSAAbOI+T6Ew9B71gIUUugvibh30eCP5enEpmovjU+Gm/BWqkc+NuRDpfLCK\nYypMrheyyZJbVPesGzzWuoOb8EHYwokTmT3FVcQzjIOCDRGs6Xy5lM0t25WC413J\ntpl9QemIOFi56CmNlkeRsKHECGLjGZd8yPQgOUECgYEA3InhfCNaHb8kkQV90l/2\nWSTXMiaOEehTm8tFebNV9TUqheWPWQpQy614b2oW24oVe6HbVZfrVoLmuYGDNBMZ\n2NMsnomw9vw/gpZV2YE1f4JtUyePoPi88tultyMwJZ/H7G9Q59/jUttxPN7oug6E\n6yMWIDqMiCkT7X3FTC9V8tw=\n-----END PRIVATE KEY-----\n"",  ""client_email"": ""firebase-adminsdk-xlhm3@seller-sense-license.iam.gserviceaccount.com"",  ""client_id"": ""112689015291110913883"",  ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",  ""token_uri"": ""https://oauth2.googleapis.com/token"",  ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",  ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-xlhm3%40seller-sense-license.iam.gserviceaccount.com"",  ""universe_domain"": ""googleapis.com""}";
                //string encoded = Base64Encode(jsonKey);
                // key was encoded first & then added below:
                string encoded = "eyAidHlwZSI6ICJzZXJ2aWNlX2FjY291bnQiLCAgInByb2plY3RfaWQiOiAic2VsbGVyIC0gc2Vuc2UgLSBsaWNlbnNlIiwgICJwcml2YXRlX2tleV9pZCI6ICI2YzljNTBlOTk2MjA1YWU0NDU0NmI5YzZlNjY0MjU0N2UyMTJmNDdlIiwgICJwcml2YXRlX2tleSI6ICItLS0tLUJFR0lOIFBSSVZBVEUgS0VZLS0tLS1cbk1JSUV2UUlCQURBTkJna3Foa2lHOXcwQkFRRUZBQVNDQktjd2dnU2pBZ0VBQW9JQkFRREtTczE3emcrQ3oyY0FcbkJZTG1sTUFDSGdReng5eXBWcDQyeFdWSW4rend0bEFIeTl4R2c2VS90aGVNMG9YYXZVR0ZoYmJkYzdoa0pPdUhcblA1cFo2dXFBVllWNWpOa0UyVnltMmVyVURLbVJkRmZQSTFCaW9lM0RQRHJPSm1LZkw4TFpBankrNjlZd21sMzJcbldwbjN4NUFuMStUR3dsYit5cmV3K0lKMGJ5V29LazQwZzVrWmtKVUFZblEwOGtRWmpJVWFxaVljWmI2SnRHNUhcbklOZ2YwT092U1ZYVEVWazNPdXRHVjhhZG1oSHhpbUwyanlJcDJYb09uQVpoYVB6ZlJzM2gyZTcwMVN6dEhOWlFcbjU1QmQzdERCenl3T1J4MUZyREZLWkVjbEZPaXY3Z1BjZHA1eUV0NXFKTUpPYkY2S0dYNHI0UUFHTmdjQXg5T2VcblhiMWtodmFSQWdNQkFBRUNnZ0VBQi8vdUtUY21kWUVsa09wMjRTN1kyc0NVZ0paMjFVYkMwQlpOYllJL0Nzd2ZcbjVUWUljSXl1VTFNY2NtNEZHM2ZNWkhjTHFxMWp5V2lOSEtLdEZFRWFLOC90L01iL1VrMzArRGR5RGhlUDJWdmpcbktOS3NBREdJZ3pYeG1xTkpsME5ha28zQVNKblBsU21XbllwYTBFSFc0MTk2R1dyWUtVQnJwQnJJd0dsZ2tTcEVcbm1YQ3BYKzlmZWFoTmRqYjYyNE5JNG5oQ3RtZGtsTlRlK05rdzdER3kycTJRbGV5ZER4cDFyQVBnMnFLdnlXK2VcbjNHK3VYc0puU1piNGVYd0E3ZVdHbklVVFdTbk1YOVNmTmVRbzNrYTJObFJxRHhPNDA0SlpUd0tnaDRwdEh4dTRcbjRlSFhzREVPM09iM1BSNkNvejZUUjJDQjVHd25vNXRLbTFtTEEvbFo0UUtCZ1FEd3F1K1VxVm9TZDA4LzlFU3ZcbmQwWmRrZmtxZ2JFa1JCdFhralowb2dib1N0TjB3OWFyc25lWUFqMmdHYnVycVE5dUluWUw2NVdHc1FDdzFOVE1cbkRMNlg3eDRmNjlGaE42NHJ0anpnUTVXNTlHQ0cvN1hSbDhRWHQ5bThjMTQweENqdThJQTNrMVBqUWF4VzBBK3NcbmpEQ1RRcXlhL1FFUEZZUWZnYXNlZndIbnNRS0JnUURYTGYrSHNwd3NTWmh4Wm5qcHJQdkhiMzBnRDhWYVh5TDdcbmxUOWNHYjhXUnpsbEswbDRxM25HNEFMVHhPcHdoT2QxYUFOTkNKSko3cXcvNXg5d01SVysydkRRMkYxbXpxb0NcblQ1dmFFaVFNZUUrSTQwQXFiN28vaDNqYzVieVd0MjFYK3pINTVBQUcyVDVCeWZCdlJHd0hwMWp6NWsyUVo4ZTVcbkhIRXhxbWlVNFFLQmdHZnNxSUE5a1JPZ1NheUlRcEN5cE1RTElObG1INlJWZEtrZ0RqdlhLN3hyYzF4Y3BQcUhcbm1uVWRvcGJjQmRwZXFyY1lVbmxiUmJwZi9MaGZiM1NkbkQvbmxjNmErbE5Ndy8xRU9JMXZJZHltMW5mMVBBSkJcbjB2K2ErSDhVSW40T3BzNW5ORGJMZTlJS3JlemU4NlhDODhialo3MlZ1enRVUXpXSHZPanlWMVJCQW9HQWF0OVhcbnVPZ0hGU0FBYk9JK1Q2RXc5QjcxZ0lVVXVndmliaDMwZUNQNWVuRXBtb3ZqVStHbS9CV3FrYytOdVJEcGZMQ0tcbll5cE1yaGV5eVpKYlZQZXNHenpXdW9PYjhFSFl3b2tUbVQzRlZjUXpqSU9DRFJHczZYeTVsTTB0MjVXQzQxM0pcbnRwbDlRZW1JT0ZpNTZDbU5sa2VSc0tIRUNHTGpHWmQ4eVBRZ09VRUNnWUVBM0luaGZDTmFIYjhra1FWOTBsLzJcbldTVFhNaWFPRWVoVG04dEZlYk5WOVRVcWhlV1BXUXBReTYxNGIyb1cyNG9WZTZIYlZaZnJWb0xtdVlHRE5CTVpcbjJOTXNub213OXZ3L2dwWlYyWUUxZjRKdFV5ZVBvUGk4OHR1bHR5TXdKWi9IN0c5UTU5L2pVdHR4UE43b3VnNkVcbjZ5TVdJRHFNaUNrVDdYM0ZUQzlWOHR3PVxuLS0tLS1FTkQgUFJJVkFURSBLRVktLS0tLVxuIiwgICJjbGllbnRfZW1haWwiOiAiZmlyZWJhc2UtYWRtaW5zZGsteGxobTNAc2VsbGVyLXNlbnNlLWxpY2Vuc2UuaWFtLmdzZXJ2aWNlYWNjb3VudC5jb20iLCAgImNsaWVudF9pZCI6ICIxMTI2ODkwMTUyOTExMTA5MTM4ODMiLCAgImF1dGhfdXJpIjogImh0dHBzOi8vYWNjb3VudHMuZ29vZ2xlLmNvbS9vL29hdXRoMi9hdXRoIiwgICJ0b2tlbl91cmkiOiAiaHR0cHM6Ly9vYXV0aDIuZ29vZ2xlYXBpcy5jb20vdG9rZW4iLCAgImF1dGhfcHJvdmlkZXJfeDUwOV9jZXJ0X3VybCI6ICJodHRwczovL3d3dy5nb29nbGVhcGlzLmNvbS9vYXV0aDIvdjEvY2VydHMiLCAgImNsaWVudF94NTA5X2NlcnRfdXJsIjogImh0dHBzOi8vd3d3Lmdvb2dsZWFwaXMuY29tL3JvYm90L3YxL21ldGFkYXRhL3g1MDkvZmlyZWJhc2UtYWRtaW5zZGsteGxobTMlNDBzZWxsZXItc2Vuc2UtbGljZW5zZS5pYW0uZ3NlcnZpY2VhY2NvdW50LmNvbSIsICAidW5pdmVyc2VfZG9tYWluIjogImdvb2dsZWFwaXMuY29tIn0=";
                string decodedKey = Base64Decode(encoded);

                firestoreDb = new FirestoreDbBuilder
                {
                    ProjectId = "seller-sense-license",
                    JsonCredentials = decodedKey
                }.Build();
            
            }

            public async Task<Dictionary<string, object>> ReadData(string docId)
            {
                //var firestoreDb = GetFirebaseDatabaseRef();
                //var docSnap = await dbref.getDoc(docRef);
                //var q = firestoreDb.Collection("lics").WhereEqualTo("", "");
                try
                {
                if (firestoreDb == null)
                    GetFirebaseDatabaseRef();
                DocumentReference dbref = firestoreDb.Collection("lics").Document(docId);

                    DocumentSnapshot dbSnap = await dbref.GetSnapshotAsync();
                    if (dbSnap.Exists)
                        return dbSnap.ToDictionary();
                    else
                        return default(Dictionary<string, object>);
                }
                catch (Exception ex)
                {
                    //throw new InvalidOperationException("Error occurred, " +
                    //    "while connecting to license server. Please check your internet connection & try again.");
                    return default(Dictionary<string, object>);
                }
            }


        //db.collection('books').where(firebase.firestore.FieldPath.documentId(), '==', 'fK3ddutEpD2qQqRMXNW5').get()
        private static string GetIds()
        {
            string deviceId = new DeviceIdBuilder()
            .OnWindows(windows => windows
                .AddProcessorId()
                .AddMotherboardSerialNumber()
                .AddSystemDriveSerialNumber())
            .ToString();
            return deviceId;
        }



        public static async void WriteErrData(string error)
        {
            try
            {
                if (firestoreDb == null)
                    GetFirebaseDatabaseRef();
                string uniqueId = GetIds();
                DocumentReference dbref = firestoreDb.Collection("errs").Document(uniqueId);

                Dictionary<string, object> updates = new Dictionary<string, object>
                {
                    { DateTime.Now.ToString(), error }
                };
                WriteResult writeResult = await dbref.SetAsync(updates);
                //await dbref.UpdateAsync(updates);
            }
            catch (Exception ex)
            {
                //throw new InvalidOperationException("Error occurred, " +
                //    "while connecting to license server. Please check your internet connection & try again.");
            }

        }

        public async void WriteData(string uniqueId, string registrationDetails)
            {
                try
                {
                if (firestoreDb == null)
                    GetFirebaseDatabaseRef();
                //var v = ReadData(uniqueId);
                //var firestoreDb = GetFirebaseDatabaseRef();
                DocumentReference dbref = firestoreDb.Collection("lics").Document(uniqueId);

                    Dictionary<string, object> updates = new Dictionary<string, object>
                {
                    { uniqueId, registrationDetails }
                };
                    WriteResult writeResult = await dbref.SetAsync(updates);
                    //await dbref.UpdateAsync(updates);
                }
                catch (Exception ex)
                {
                    //throw new InvalidOperationException("Error occurred, " +
                    //    "while connecting to license server. Please check your internet connection & try again.");
                }

            }


            private static string Base64Decode(string base64EncodedData)
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }

            private static string Base64Encode(string plainText)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                return System.Convert.ToBase64String(plainTextBytes);
            }

        //}
    }
}

