using AutoMapper;
using Data.AppException;
using Data.Cache;
using Data.DataAccessLayer;
using Data.Enums;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface ISettingService
    {
        List<PairModel> GetKeys(string? key);
        void SetupSettings();
        int AddSetting(List<PairModel> models);
        string UpdateSetting(string key, StringModel model);
        string RemoveSetting(string key);
    }
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public SettingService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void SetupSettings()
        {
            var data = _dbContext.SystemSettings.ToList();

            foreach (var key in Enum.GetValues(typeof(MandatorySettings)))
            {
                if (data.FirstOrDefault(f => f.Key == key.ToString()) == null)
                {
                    throw new Exception("Setting Key: " + key.ToString() + " must have value!");
                }
            }

            CacheSetting.CacheSettings = _mapper.Map<List<PairModel>>(data);
        }

        public List<PairModel> GetKeys(string? key)
        {
            var data = _dbContext.SystemSettings.Where(f => string.IsNullOrEmpty(key) || key == f.Key).ToList();
            return _mapper.Map<List<PairModel>>(data);
        }

        public int AddSetting(List<PairModel> models)
        {
            foreach (var item in models)
            {
                var existedData = _dbContext.SystemSettings.FirstOrDefault(f => f.Key == item.Key);
                if (existedData != null) throw new AppException("Key existed!");
            }
            var newSettings = _mapper.Map<List<SettingService>>(models);

            _dbContext.AddRange(newSettings);
            _dbContext.SaveChanges();

            SetupSettings();

            return models.Count;
        }

        public string UpdateSetting(string key, StringModel model)
        {
            var data = _dbContext.SystemSettings.FirstOrDefault(f => f.Key == key);

            data.Value = model.Description;

            _dbContext.Update(data);
            _dbContext.SaveChanges();

            SetupSettings();

            return key;
        }

        public string RemoveSetting(string key)
        {
            foreach (var mandatoryKey in Enum.GetValues(typeof(MandatorySettings)))
            {
                if (mandatoryKey.ToString().ToUpper().Equals(key.Trim().ToUpper()))
                {
                    throw new AppException("Can't remove setting Key: " + mandatoryKey.ToString() + "!");
                }
            }

            var data = _dbContext.SystemSettings.FirstOrDefault(f => f.Key == key);

            if (data == null) throw new AppException("Invalid key");

            _dbContext.Remove(data);
            _dbContext.SaveChanges();

            SetupSettings();

            return key;
        }
    }
}
