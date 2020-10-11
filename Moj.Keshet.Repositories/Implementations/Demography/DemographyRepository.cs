using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Concurrent;
using Moj.Demography.Rest.Proxy.Interfaces;
using Moj.Demography.Rest.Proxy.Contracts;
using Moj.Core.Rest.Common.Logging;
using Moj.Keshet.Domain.ExampleModels.CodeTables;
using Moj.Keshet.Repositories.Interfaces.Demography;
using Moj.Keshet.Domain.Extensions;

namespace Moj.Keshet.Repositories.Implementations.Demography
{
    public class DemographyRepository : IDemographyRepository, IDemographyLoader
    {
        #region Members

        //private static List<Country> _countriesStore = null;
        //private static List<Country> _allCountriesStore = null;
        //private static List<ExtendedCity> _citiesStore = null;
        //private static ConcurrentDictionary<int, List<ExtendedStreet>> _streetsStore = null;
        //private static ConcurrentDictionary<int, GetCodeTableResponse> _streetCodePairsStore = null;
        //private static GetCodeTableResponse _cityCodePairsStore = null;

        private List<Country> _countriesStore = null;
        private List<Country> _allCountriesStore = null;
        private List<ExtendedCity> _citiesStore = null;
        private ConcurrentDictionary<int, List<ExtendedStreet>> _streetsStore = null;
        private ConcurrentDictionary<int, GetCodeTableResponse> _streetCodePairsStore = null;
        private GetCodeTableResponse _cityCodePairsStore = null;

        private DateTime _lastPerceptionDate = DateTime.MinValue;

        //private static bool _initialized = false;
        //private static object _locker = new object();

        private bool _initialized = false;
        private object _locker = new object();

        private readonly IDemographyCore _demography;
        private readonly ILogger _logger;

        #endregion Members

        #region Properties

        //public static DateTime LastPerceptionDate { get; set; }
        public DateTime LastPerceptionDate { get { return _lastPerceptionDate; } }

        public List<Country> Countries
        {
            get { return _countriesStore.DeepClone(); }
        }

        public List<Country> BirthCountries
        {
            get { return _allCountriesStore.DeepClone(); }
        }

        public List<ExtendedCity> AllCities
        {
            get { return _citiesStore.DeepClone(); }
        }

        public GetCodeTableResponse GetCityCodePairs
        {
            get { return _cityCodePairsStore.DeepClone(); }
        }

        #endregion Properties

        #region Ctor

        public DemographyRepository(ILogger logger, IDemographyCore demography)
        {
            _logger = logger;
            _demography = demography;
        }

        #endregion Ctor

        #region load

        //public static void CheckLastPerceptionDate(ILogger logger, IDemographyCore demography)
        public void CheckLastPerceptionDate()
        {
            DateTime? lastPerceptionDate;

            try
            {
                //lastPerceptionDate = demography.GetLastPerceptionDate().Data;
                lastPerceptionDate = _demography.GetLastPerceptionDate().Data;
                if (!lastPerceptionDate.HasValue) throw new Exception("LastPerceptionDate has no value");
            }
            catch (Exception e)
            {
                //logger.ErrorException("CheckLastPerceptionDate failed", e);
                _logger.ErrorException("CheckLastPerceptionDate failed", e);
                return;
            }

            if (LastPerceptionDate < lastPerceptionDate.Value)
            {
                _initialized = false;
                //LoadDemography(logger, demography, lastPerceptionDate.Value);
                LoadDemography(lastPerceptionDate.Value);
            }
        }

        // TODOs
        // error
        // empties

        //private static void LoadDemography(ILogger logger, IDemographyCore demography, DateTime lastPerceptionDate)
        private void LoadDemography(DateTime lastPerceptionDate)
        {
            try
            {
                if (_initialized) return;

                lock (_locker)
                {
                    if (_initialized) return;

                    //logger.Info("Demography loading began.");
                    _logger.Info("Demography loading began.");

                    _streetsStore = new ConcurrentDictionary<int, List<ExtendedStreet>>();
                    _streetCodePairsStore = new ConcurrentDictionary<int, GetCodeTableResponse>();

                    // load countries
                    //var taskGetCountries = demography.GetCountriesAsync();
                    var taskGetCountries = _demography.GetCountriesAsync();

                    // load birth countries
                    //var taskGetBirthCountries = demography.GetBirthCountriesAsync();
                    var taskGetBirthCountries = _demography.GetBirthCountriesAsync();

                    // laod cities
                    //var taskGetCities = demography.GetExtendedCitiesAsync();
                    var taskGetCities = _demography.GetExtendedCitiesAsync();

                    Task.WaitAll(taskGetCountries, taskGetBirthCountries, taskGetBirthCountries, taskGetCities);

                    _allCountriesStore = taskGetBirthCountries.Result.Countries;
                    _countriesStore = taskGetCountries.Result.Countries;
                    _citiesStore = taskGetCities.Result.ExtendedCities;

                    _cityCodePairsStore = new GetCodeTableResponse()
                    {
                        Context = "Cities",
                        CodeTableDictionary = _citiesStore
                        .Where(a => a.ShemYeshuv.Equals(a.ShemYeshuvNirdaf))
                        .Select(a => new CodeTablePair()
                        {
                            Key = a.MisparYeshuv,
                            Value = a.ShemYeshuv
                        }).OrderBy(a => a.Value).ToList<CodeTablePair>()
                    };

                    _lastPerceptionDate = lastPerceptionDate;
                }
            }
            catch (Exception e)
            {
                //logger.ErrorException("Error while loading the demography", e);
                _logger.ErrorException("Error while loading the demography", e);
            }
        }

        #endregion

        #region Methods

        public List<ExtendedStreet> GetStreetsByCity(int cityId)
        {
            return _streetsStore.GetOrAdd(cityId, key =>
            {
                return _demography.GetExtendedStreetsAsync(new GetExtendedStreetsRequest { MisparYeshuv = key }).Result.ExtendedStreets;
            })
            .DeepClone();
        }

        public async Task<List<ExtendedStreet>> GetStreetsByCityAsync(int cityId)
        {
            return await Task.Run(() => _streetsStore.GetOrAdd(cityId, key =>
            {
                return _demography.GetExtendedStreetsAsync(new GetExtendedStreetsRequest { MisparYeshuv = key }).Result.ExtendedStreets;
            })
            .DeepClone());
        }

        public ExtendedStreet GetStreet(int cityId, int streetId)
        {
            return GetStreetsByCity(cityId).FirstOrDefault(s => s.MisparRechov == streetId).DeepClone();
        }

        public async Task<ExtendedStreet> GetStreetAsync(int cityId, int streetId)
        {
            return await Task.Run(() => GetStreetsByCity(cityId).FirstOrDefault(s => s.MisparRechov == streetId).DeepClone());
        }

        public ExtendedCity GetCity(int cityId)
        {
            return _citiesStore.FirstOrDefault(c => c.MisparYeshuv == cityId).DeepClone();
        }

        public async Task<ExtendedCity> GetCityAsync(int cityId)
        {
            return await Task.Run(() => _citiesStore.FirstOrDefault(c => c.MisparYeshuv == cityId).DeepClone());
        }

        public ExtendedCity GetCityBySemel(int citySemel)
        {
            return _citiesStore.FirstOrDefault(c => c.SemelYeshuv == citySemel).DeepClone();
        }

        public async Task<ExtendedCity> GetCityBySemelAsync(int citySemel)
        {
            return await Task.Run(() => _citiesStore.FirstOrDefault(c => c.SemelYeshuv == citySemel).DeepClone());
        }

        public Country GetCountry(int countryId)
        {
            return _countriesStore.FirstOrDefault(c => c.MisparEretz == countryId).DeepClone();
        }

        public async Task<Country> GetCountryAsync(int countryId)
        {
            return await Task.Run(() => _countriesStore.FirstOrDefault(c => c.MisparEretz == countryId).DeepClone());
        }

        public Country GetBirthCountry(int countryId)
        {
            return _allCountriesStore.FirstOrDefault(c => c.MisparEretz == countryId).DeepClone();
        }

        public async Task<Country> GetBirthCountryAsync(int countryId)
        {
            return await Task.Run(() => _allCountriesStore.FirstOrDefault(c => c.MisparEretz == countryId).DeepClone());
        }

        public int? GetZip(int cityId, int streetId, int houseNumber, string entrance)
        {
            var zip = _demography.GetZip(new GetZipRequest
            {
                MisparYeshuv = cityId,
                MisparRechov = streetId,
                MisparBait = houseNumber,
                Knisa = string.IsNullOrEmpty(entrance) ? ' ' : entrance[0]
            }).Zip;
            return zip == -1 ? (int?)null : zip;
        }

        public async Task<int?> GetZipAsync(int cityId, int streetId, int houseNumber, string entrance)
        {
            var zip = (await _demography.GetZipAsync(new GetZipRequest
            {
                MisparYeshuv = cityId,
                MisparRechov = streetId,
                MisparBait = houseNumber,
                Knisa = string.IsNullOrEmpty(entrance) ? ' ' : entrance[0]
            })).Zip;
            return zip == -1 ? (int?)null : zip;
        }

        public int? GetZip(int cityId, int poBox)
        {
            var zip = _demography.GetZipForPOBox(new GetZipForPOBoxRequest
            {
                MisparYeshuv = cityId,
                MisparTaDoar = poBox
            }).Zip;
            return zip == -1 ? (int?)null : zip;
        }

        public async Task<int?> GetZipAsync(int cityId, int poBox)
        {
            var zip = (await _demography.GetZipForPOBoxAsync(new GetZipForPOBoxRequest
            {
                MisparYeshuv = cityId,
                MisparTaDoar = poBox
            })).Zip;
            return zip == -1 ? (int?)null : zip;
        }

        #endregion Methods
    }
}
