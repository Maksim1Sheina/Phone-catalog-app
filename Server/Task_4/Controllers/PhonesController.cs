using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Task_4.Models;
using Task_4.Data_Transfer_Object;
using System.Web.Http.Cors;
using System.IO;
using System.Web;
using System.Net.Http;

namespace Task_4.Controllers
{
    [EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
    public class PhonesController : ApiController
    {
        private Task_4Context db = new Task_4Context();

        // GET: api/Phones
        public IList<PhoneShortInformation> GetPhones()
        {
            try
            {
                var rQuery = from p in db.Phones.Include(s => s.Images)
                             select new PhoneShortInformation()
                             {
                                 ID = p.ID,
                                 Name = p.Name,
                                 Description = p.Description,
                                 MainImageURL = p.Images.Where(s => s.PhoneID == p.ID).FirstOrDefault().ImageURL
                             };

                var phones = rQuery.ToList();

                foreach (var item in phones)
                {
                    item.Description = SplitDesc(item.Description);
                }

                return phones;
            }

            catch(HttpResponseException error)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("Server error. Try again later. \n Server errors: {0}", error.Message)));
            }
        }

        private string SplitDesc(string Description)
        {
            try
            {
                string[] arrString = Description.Split(' ');
                string outValue = "";
                foreach (var item in arrString)
                {
                    if (outValue.Length < 50)
                        outValue = outValue + " " + item;

                    else
                        break;
                }

                outValue = outValue + "...";
                return outValue;
            }
            catch(HttpResponseException error)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("Server error. Try again later. \n Server errors: {0}", error.Message)));
            }
        }

        // GET: api/Phones/5
        [ResponseType(typeof(PhoneDTO))]
        public async Task<IHttpActionResult> GetPhone(int id)
        {
            try
            {
                var searchedPhone = await db.Phones
                    .Include(s => s.Availabilities)
                    .Include(s => s.CameraFeatures)
                    .Include(s => s.Images)
                    .Include(s => s.PlatformParameters)
                    .Where(p => p.ID == id)
                    .SingleOrDefaultAsync();

                if (searchedPhone == null)
                {
                    return NotFound();
                }

                var phone = new PhoneDTO()
                {
                    AdditionalFeatures = searchedPhone.AdditionalFeatures,
                    BatteryStandbyTime = searchedPhone.BatteryStandbyTime,
                    BatteryTalkTime = searchedPhone.BatteryTalkTime,
                    BatteryType = searchedPhone.BatteryType,
                    CameraPrimary = searchedPhone.CameraPrimary,
                    ConnectivityBluetooth = searchedPhone.ConnectivityBluetooth,
                    ConnectivityCell = searchedPhone.ConnectivityCell,
                    ConnectivityGPS = searchedPhone.ConnectivityGPS,
                    ConnectivityInfrared = searchedPhone.ConnectivityInfrared,
                    ConnectivityWiFi = searchedPhone.ConnectivityWiFi,
                    Description = searchedPhone.Description,
                    DisplayScreenResolution = searchedPhone.DisplayScreenResolution,
                    DisplayScreenSize = searchedPhone.DisplayScreenSize,
                    DisplayTouchScreen = searchedPhone.DisplayTouchScreen,
                    HardwareAccelerometer = searchedPhone.HardwareAccelerometer,
                    HardwareAudioJack = searchedPhone.HardwareAudioJack,
                    HardwareCPU = searchedPhone.HardwareCPU,
                    HardwareFMRadio = searchedPhone.HardwareFMRadio,
                    HardwarePhysicalKeyboard = searchedPhone.HardwarePhysicalKeyboard,
                    HardwareUSB = searchedPhone.HardwareUSB,
                    Name = searchedPhone.Name,
                    Width = searchedPhone.Width,
                    Height = searchedPhone.Height,
                    Depth = searchedPhone.Depth,
                    Weight = searchedPhone.Weight,
                    StorageFlash = searchedPhone.StorageFlash,
                    StorageRAM = searchedPhone.StorageRAM,
                    PlatformType = searchedPhone.PlatformParameters.PlatformType,
                    PlatrormVersion = searchedPhone.PlatformParameters.PlatrormVersion,
                    PlatformUI = searchedPhone.PlatformParameters.PlatformUI,

                    Availabilities = ToListFromRequaest(searchedPhone.Availabilities),
                    CameraFeatures = ToListFromRequaest(searchedPhone.CameraFeatures),
                    Images = ToListFromRequaest(searchedPhone.Images)
                };

                return Ok(phone);
            }

            catch (HttpResponseException error)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("Server error. Try again later. \n Server errors: {0}", error.Message)));
            }
        }

        private List<string> ToListFromRequaest(ICollection<PhoneAvailability> list)
        {
            try
            {
                var outList = new List<string>();

                foreach (var item in list)
                {
                    outList.Add(item.Availability);
                }

                return outList;
            }

            catch (HttpResponseException error)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("Server error. Try again later. \n Server errors: {0}", error.Message)));
            }
        }

        private List<string> ToListFromRequaest(ICollection<PhoneCameraFeature> list)
        {
            try
            {
                var outList = new List<string>();

                foreach (var item in list)
                {
                    outList.Add(item.CameraFeature);
                }

                return outList;
            }
            catch (HttpResponseException error)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("Server error. Try again later. \n Server errors: {0}", error.Message)));
            }
        }

        private List<string> ToListFromRequaest(ICollection<PhoneImage> list)
        {
            try
            {
                var outList = new List<string>();

                foreach (var item in list)
                {
                    outList.Add(item.ImageURL);
                }

                return outList;
            }

            catch (HttpResponseException error)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("Server error. Try again later. \n Server errors: {0}", error.Message)));
            }
        }

        // PUT: api/Phones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhone(int id, PhoneDTO phoneValue)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != phoneValue.ID)
                {
                    return BadRequest();
                }

                Phone phone = new Phone()
                {
                    ID = id,
                    AdditionalFeatures = phoneValue.AdditionalFeatures,
                    BatteryStandbyTime = phoneValue.BatteryStandbyTime + " hours",
                    BatteryTalkTime = phoneValue.BatteryTalkTime + " hours",
                    BatteryType = phoneValue.BatteryType,
                    CameraPrimary = phoneValue.CameraPrimary,
                    ConnectivityBluetooth = phoneValue.ConnectivityBluetooth,
                    ConnectivityCell = phoneValue.ConnectivityCell,
                    ConnectivityGPS = phoneValue.ConnectivityGPS,
                    ConnectivityInfrared = phoneValue.ConnectivityInfrared,
                    ConnectivityWiFi = phoneValue.ConnectivityWiFi,
                    Description = phoneValue.Description,
                    DisplayScreenResolution = phoneValue.DisplayScreenResolution,
                    DisplayScreenSize = phoneValue.DisplayScreenSize,
                    DisplayTouchScreen = phoneValue.DisplayTouchScreen,
                    HardwareAccelerometer = phoneValue.HardwareAccelerometer,
                    HardwareAudioJack = phoneValue.HardwareAudioJack,
                    HardwareCPU = phoneValue.HardwareCPU,
                    HardwareFMRadio = phoneValue.HardwareFMRadio,
                    HardwarePhysicalKeyboard = phoneValue.HardwarePhysicalKeyboard,
                    HardwareUSB = phoneValue.HardwareUSB,
                    Name = phoneValue.Name,
                    Width = phoneValue.Width,
                    Height = phoneValue.Height,
                    Depth = phoneValue.Depth,
                    Weight = phoneValue.Weight,
                    StorageFlash = phoneValue.StorageFlash,
                    StorageRAM = phoneValue.StorageRAM
                };
                db.Entry(phone).State = EntityState.Modified;

                var availabilitiesQuery = db.PhoneAvailabilities.Where(s => s.PhoneID == id).ToList();
                foreach (var item in availabilitiesQuery)
                {
                    db.PhoneAvailabilities.Remove(item);
                }

                foreach (var item in phoneValue.Availabilities)
                {
                    PhoneAvailability availabilities = new PhoneAvailability()
                    {
                        Availability = item,
                        PhoneID = id
                    };

                    db.PhoneAvailabilities.Add(availabilities);
                }

                var featuresQuery = db.PhoneCameraFeatures.Where(s => s.PhoneID == id).ToList();
                foreach (var item in featuresQuery)
                {
                    db.PhoneCameraFeatures.Remove(item);
                }

                foreach (var item in phoneValue.CameraFeatures)
                {
                    PhoneCameraFeature feature = new PhoneCameraFeature()
                    {
                        CameraFeature = item,
                        PhoneID = id
                    };

                    db.PhoneCameraFeatures.Add(feature);
                }

                PhonePlatformParameters param = new PhonePlatformParameters()
                {
                    PhoneID = id,
                    PlatformType = phoneValue.PlatformType,
                    PlatrormVersion = phoneValue.PlatrormVersion,
                    PlatformUI = phoneValue.PlatformUI
                };
                db.Entry(param).State = EntityState.Modified;

                var imageQuery = db.PhoneImages.Where(s => s.PhoneID == id).ToList();
                foreach (var item in imageQuery)
                {
                    db.PhoneImages.Remove(item);
                }

                List<string> images = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~/Album/")).ToList();
                List<string> virtual_paths = new List<string>();
                foreach (var item in images)
                {
                    virtual_paths.Add(VirtualUrl("Album/" + Path.GetFileName(item)));
                }

                foreach (var item in phoneValue.Images)
                {
                    if (virtual_paths.Contains(item))
                    {
                        PhoneImage image = new PhoneImage()
                        {
                            ImageURL = item,
                            PhoneID = id
                        };

                        db.PhoneImages.Add(image);
                    }
                }

                await db.SaveChangesAsync();
            }

            catch (HttpResponseException error)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("Server error. Try again later. \n Server errors: {0}", error.Message)));
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost()]
        [Route("api/Phones/Upload")]
        public List<string> UploadFiles()
        {
            try
            {
                int iUploadedCnt = 0;
                List<string> ImagePath = new List<string>();

                // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
                Random r = new Random();

                string sPath = "";
                sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Album/");

                System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

                // CHECK THE FILE COUNT.
                for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
                {
                    System.Web.HttpPostedFile hpf = hfc[iCnt];

                    if (hpf.ContentLength > 0)
                    {
                        var addedName = r.Next(10000, 10000000).ToString();

                        // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                        if (!File.Exists(sPath + addedName + Path.GetFileName(hpf.FileName)))
                        {
                            // SAVE THE FILES IN THE FOLDER.
                            hpf.SaveAs(sPath + addedName + Path.GetFileName(hpf.FileName));
                            iUploadedCnt = iUploadedCnt + 1;
                            ImagePath.Add(VirtualUrl("Album/" + addedName + Path.GetFileName(hpf.FileName)));
                        }
                    }
                }

                // RETURN A MESSAGE (OPTIONAL).
                if (iUploadedCnt > 0)
                {
                    return ImagePath;
                }
                else
                {
                    ImagePath.Clear();
                    ImagePath.Add("Upload Failed");
                    return ImagePath;
                }
            }

            catch (HttpResponseException error)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("Server error. Try again later. \n Server errors: {0}", error.Message)));
            }
        }

        // POST: api/Phones
        [ResponseType(typeof(PhoneDTO))]
        public async Task<IHttpActionResult> PostPhone(PhoneDTO phoneValue)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Phone phone = new Phone()
                {
                    AdditionalFeatures = phoneValue.AdditionalFeatures,
                    BatteryStandbyTime = phoneValue.BatteryStandbyTime + " hours",
                    BatteryTalkTime = phoneValue.BatteryTalkTime + " hours",
                    BatteryType = phoneValue.BatteryType,
                    CameraPrimary = phoneValue.CameraPrimary,
                    ConnectivityBluetooth = phoneValue.ConnectivityBluetooth,
                    ConnectivityCell = phoneValue.ConnectivityCell,
                    ConnectivityGPS = phoneValue.ConnectivityGPS,
                    ConnectivityInfrared = phoneValue.ConnectivityInfrared,
                    ConnectivityWiFi = phoneValue.ConnectivityWiFi,
                    Description = phoneValue.Description,
                    DisplayScreenResolution = phoneValue.DisplayScreenResolution,
                    DisplayScreenSize = phoneValue.DisplayScreenSize,
                    DisplayTouchScreen = phoneValue.DisplayTouchScreen,
                    HardwareAccelerometer = phoneValue.HardwareAccelerometer,
                    HardwareAudioJack = phoneValue.HardwareAudioJack,
                    HardwareCPU = phoneValue.HardwareCPU,
                    HardwareFMRadio = phoneValue.HardwareFMRadio,
                    HardwarePhysicalKeyboard = phoneValue.HardwarePhysicalKeyboard,
                    HardwareUSB = phoneValue.HardwareUSB,
                    Name = phoneValue.Name,
                    Width = phoneValue.Width,
                    Height = phoneValue.Height,
                    Depth = phoneValue.Depth,
                    Weight = phoneValue.Weight,
                    StorageFlash = phoneValue.StorageFlash,
                    StorageRAM = phoneValue.StorageRAM
                };
                db.Phones.Add(phone);
                await db.SaveChangesAsync();

                foreach (var item in phoneValue.Availabilities)
                {
                    PhoneAvailability availabilities = new PhoneAvailability()
                    {
                        Availability = item,
                        PhoneID = phone.ID
                    };

                    db.PhoneAvailabilities.Add(availabilities);
                }

                foreach (var item in phoneValue.CameraFeatures)
                {
                    PhoneCameraFeature feature = new PhoneCameraFeature()
                    {
                        CameraFeature = item,
                        PhoneID = phone.ID
                    };

                    db.PhoneCameraFeatures.Add(feature);
                }

                PhonePlatformParameters param = new PhonePlatformParameters()
                {
                    PhoneID = phone.ID,
                    PlatformType = phoneValue.PlatformType,
                    PlatrormVersion = phoneValue.PlatrormVersion,
                    PlatformUI = phoneValue.PlatformUI
                };
                db.PhonePlatformParameters.Add(param);

                List<string> images = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~/Album/")).ToList();
                List<string> virtual_paths = new List<string>();
                foreach (var item in images)
                {
                    virtual_paths.Add(VirtualUrl("Album/" + Path.GetFileName(item)));
                }

                foreach (var item in phoneValue.Images)
                {
                    if (virtual_paths.Contains(item))
                    {
                        PhoneImage image = new PhoneImage()
                        {
                            ImageURL = item,
                            PhoneID = phone.ID
                        };

                        db.PhoneImages.Add(image);
                    }
                }

                await db.SaveChangesAsync();

                return StatusCode(HttpStatusCode.OK);
            }

            catch(HttpResponseException error)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("Server error. Try again later. \n Server errors: {0}", error.Message)));
            }
        }

        public string VirtualUrl(string relativeUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(relativeUrl))
                    return relativeUrl;

                if (relativeUrl.StartsWith("/"))
                    relativeUrl = relativeUrl.Insert(0, "~");
                if (!relativeUrl.StartsWith("~/"))
                    relativeUrl = relativeUrl.Insert(0, "~/");

                var url = HttpContext.Current.Request.Url;
                var port = url.Port != 80 ? (":" + url.Port) : String.Empty;

                return $"{url.Scheme}://{url.Host}{port}{VirtualPathUtility.ToAbsolute(relativeUrl)}";
            }

            catch (HttpResponseException error)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("Server error. Try again later. \n Server errors: {0}", error.Message)));
            }
        }

        // DELETE: api/Phones/5
        [ResponseType(typeof(PhoneDTO))]
        public async Task<IHttpActionResult> DeletePhone(int id)
        {
            try
            {
                Phone phone = await db.Phones.FindAsync(id);
                if (phone == null)
                {
                    return NotFound();
                }

                db.Phones.Remove(phone);
                await db.SaveChangesAsync();

                return Ok(phone);
            }

            catch (HttpResponseException error)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("Server error. Try again later. \n Server errors: {0}", error.Message)));
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhoneExists(int id)
        {
            return db.Phones.Count(e => e.ID == id) > 0;
        }
    }
}