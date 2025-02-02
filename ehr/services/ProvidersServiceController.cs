﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EMR.WebAPI.ehr.models;

namespace EMR.WebAPI.ehr.services
{
    public class ProvidersServiceController : ApiController
    {
        [HttpGet]
        [Route("~/api/getProviders/{dbname}")]
        public IHttpActionResult GetProviders(string dbname)
        {
            ServiceRequestStatus status;
            List<ProviderViewModel> vmList = new List<ProviderViewModel>();

            try
            {
                EHRDB db = new EHRDB();
                db.Database.Connection.ConnectionString = db.Database.Connection.ConnectionString.Replace("HK_MASTER", dbname);
                List<Provider> providers = db.Providers.Where(x => x.IsCompany == false).ToList();

                foreach (var r in providers)
                {
                    vmList.Add(new ProviderViewModel(r));
                }

                status = new ServiceRequestStatus
                {
                    IsSuccess = true,
                    Data = vmList
                };
            }
            catch (Exception e)
            {
                status = new ServiceRequestStatus
                {
                    IsSuccess = false,
                    Data = e
                };
            }

            return Ok(new { results = status });
        }

        [HttpGet]
        [Route("~/api/getGroups/{dbname}")]
        public IHttpActionResult GetGroups(string dbname)
        {
            ServiceRequestStatus status;
            List<ProviderViewModel> vmList = new List<ProviderViewModel>();

            try
            {
                EHRDB db = new EHRDB();
                db.Database.Connection.ConnectionString = db.Database.Connection.ConnectionString.Replace("HK_MASTER", dbname);
                List<Provider> results = db.Providers.Where(x => x.IsCompany == true).ToList();

                foreach (var r in results)
                {
                    vmList.Add(new ProviderViewModel(r));
                }

                status = new ServiceRequestStatus
                {
                    IsSuccess = true,
                    Data = vmList
                };
            }
            catch (Exception e)
            {
                status = new ServiceRequestStatus
                {
                    IsSuccess = false,
                    Data = e
                };
            }

            return Ok(new { results = status });
        }

        [HttpGet]
        [Route("~/api/getProviderById/{dbname}/{id}")]
        public IHttpActionResult GetProviderById(string dbname, int id)
        {
            ServiceRequestStatus status;
            Provider provider = new Provider();
            provider.IsCompany = false;

            try
            {
                if (id > 0)
                {
                    EHRDB db = new EHRDB();
                    db.Database.Connection.ConnectionString = db.Database.Connection.ConnectionString.Replace("HK_MASTER", dbname);
                    provider = db.Providers.Find(id);
                }

                status = new ServiceRequestStatus
                {
                    IsSuccess = true,
                    Data = provider
                };
            }
            catch (Exception e)
            {
                status = new ServiceRequestStatus
                {
                    IsSuccess = false,
                    Data = e
                };
            }

            return Ok(new { result = status });
        }

        [HttpGet]
        [Route("~/api/getGroupById/{dbname}/{id}")]
        public IHttpActionResult GetGroupById(string dbname, int id)
        {
            ServiceRequestStatus status;
            Provider provider = new Provider();
            provider.IsCompany = true;

            try
            {
                if (id > 0)
                {
                    EHRDB db = new EHRDB();
                    db.Database.Connection.ConnectionString = db.Database.Connection.ConnectionString.Replace("HK_MASTER", dbname);
                    provider = db.Providers.Find(id);
                }

                status = new ServiceRequestStatus
                {
                    IsSuccess = true,
                    Data = provider
                };
            }
            catch (Exception e)
            {
                status = new ServiceRequestStatus
                {
                    IsSuccess = false,
                    Data = e
                };
            }

            return Ok(new { result = status });
        }

        [Route("~/api/updateProvider/{dbname}")]
        public IHttpActionResult UpdateProvider(Provider provider, string dbname)
        {
            ServiceRequestStatus status;
            Provider p;

            try
            {
                EHRDB db = new EHRDB();
                db.Database.Connection.ConnectionString = db.Database.Connection.ConnectionString.Replace("HK_MASTER", dbname);
                if (provider.Id > 0)
                {
                    p = db.Providers.Find(provider.Id);
                }
                else
                {
                    p = new Provider
                    {
                        SystemNoteKey = System.Guid.NewGuid().ToString(),
                    };
                }

                p.EIN = provider.EIN;
                p.Email = provider.Email;
                p.Fax = provider.Fax;
                p.FirstName = provider.FirstName;
                p.LastName = provider.LastName;
                p.License = provider.License;
                p.MiddleName = provider.MiddleName;
                p.NPI = provider.NPI;
                p.Phone_1 = provider.Phone_1;
                p.Phone_2 = provider.Phone_2;
                p.SSN = provider.SSN;
                p.Suffix = provider.Suffix;
                p.TaxonomyCodeId = provider.TaxonomyCodeId;

                p.Address_1 = provider.Address_1;
                p.Address_2 = provider.Address_2;
                p.City = provider.City;
                p.State = provider.State;
                p.Zip = provider.Zip;

                if (p.Id <= 0)
                {
                    p.IsCompany = provider.IsCompany;
                    db.Providers.Add(p);
                }

                db.SaveChanges();
                status = new ServiceRequestStatus
                {
                    IsSuccess = true,
                    Data = p.Id
                };
            }
            catch (Exception e)
            {
                status = new ServiceRequestStatus
                {
                    IsSuccess = false,
                    Data = e
                };
            }

            return Ok(new { result = status });
        }

        /*
        [Route("api/services/deleteProvider/{id}")]
        public IHttpActionResult DeleteProvider(int id)
        {
            ServiceRequestStatus status;
            try
            {
                Provider p;
                EHRDB db = new EHRDB();
                p = db.Providers.Find(id);
                db.Providers.Remove(p);
                status = new ServiceRequestStatus
                {
                    IsSuccess = true,
                    Data = null
                };
            }
            catch (Exception e)
            {
                status = new ServiceRequestStatus
                {
                    IsSuccess = false,
                    Data = e
                };
            }

            return Ok(new { result = status });
        }
        */
    }
}