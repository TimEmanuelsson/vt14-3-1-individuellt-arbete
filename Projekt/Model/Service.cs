using Projekt.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Model
{
    public class Service
    {
        #region Medlem metoder

        private MedlemDAL _medlemDAL;

        private MedlemDAL MedlemDAL
        {
            get { return _medlemDAL ?? (_medlemDAL = new MedlemDAL()); }
        }

        public Medlem GetMedlem(int Medid)
        {
            return MedlemDAL.GetMedlem(Medid);
        }

        public IEnumerable<Medlem> GetMedlemmar()
        {
            return MedlemDAL.GetMedlemmar();
        }

        public void DeleteMedlem(int Medid)
        {
            MedlemDAL.DeleteMedlem(Medid);
        }

        public void SaveMedlem(Medlem medlem)
        {
            var validationContext = new ValidationContext(medlem);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(medlem, validationContext, validationResults, true))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (medlem.Medid == 0)
            {
                MedlemDAL.InsertMedlem(medlem);
            }
            else
            {
                MedlemDAL.UpdateMedlem(medlem);
            }
        }

        #endregion

        #region Band methoder

        private BandDAL _bandDAL;

        private BandDAL BandDAL
        {
            get { return _bandDAL ?? (_bandDAL = new BandDAL()); }
        }

        public IEnumerable<Band> GetBands()
        {
            return BandDAL.GetBands();
        }

        public Band GetBand(int Bandid)
        {
            return BandDAL.GetBand(Bandid);
        }

        public void SaveBand(Band band)
        {

            var validationContext = new ValidationContext(band);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(band, validationContext, validationResults, true))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (band.Bandid == 0)
            {
                BandDAL.InsertBand(band);
            }
            else
            {
                BandDAL.UpdateBand(band);
            }
        }

        public void DeleteBand(int bandid)
        {
            BandDAL.DeleteBand(bandid);
        }

        #endregion

        #region Huvudroll methoder

        private HuvudrollDAL _huvudrollDAL;

        private HuvudrollDAL HuvudrollDAL
        {
            get { return _huvudrollDAL ?? (_huvudrollDAL = new HuvudrollDAL()); }
        }

        public IEnumerable<Huvudroll> GetHuvudroller()
        {
            return HuvudrollDAL.GetHuvudroller();
        }

        public Huvudroll GetHuvudroll(int Rollid)
        {
            return HuvudrollDAL.GetHuvudroll(Rollid);
        }

        public void SaveHuvudroll(Huvudroll huvudroll)
        {

            var validationContext = new ValidationContext(huvudroll);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(huvudroll, validationContext, validationResults, true))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (huvudroll.Rollid != 0)
            {
                HuvudrollDAL.UpdateHuvudroll(huvudroll);
            }
        }

        #endregion
    }
}