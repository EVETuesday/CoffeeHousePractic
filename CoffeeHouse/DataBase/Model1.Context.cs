﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeeHouse.DataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities5 : DbContext
    {
        public Entities5()
            : base("name=Entities5")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Check> Check { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<EmloeeWorkShift> EmloeeWorkShift { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<LevelDiscount> LevelDiscount { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductList> ProductList { get; set; }
        public virtual DbSet<ProductSupply> ProductSupply { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<WorkShift> WorkShift { get; set; }
        public virtual DbSet<Emploee> Emploee { get; set; }
        public virtual DbSet<VW_AllProductInfo> VW_AllProductInfo { get; set; }
        public virtual DbSet<VW_CanMaxSale> VW_CanMaxSale { get; set; }
        public virtual DbSet<VW_LevelDiscountClient> VW_LevelDiscountClient { get; set; }
        public virtual DbSet<VW_TheBiggestClient> VW_TheBiggestClient { get; set; }
        public virtual DbSet<VW_WorkShiftEmploee> VW_WorkShiftEmploee { get; set; }
    
        public virtual int PR_AVGPriceProduct()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PR_AVGPriceProduct");
        }
    
        public virtual ObjectResult<PR_getStuffExpirationDate_Result> PR_getStuffExpirationDate(Nullable<int> aTime, Nullable<int> bTime)
        {
            var aTimeParameter = aTime.HasValue ?
                new ObjectParameter("aTime", aTime) :
                new ObjectParameter("aTime", typeof(int));
    
            var bTimeParameter = bTime.HasValue ?
                new ObjectParameter("bTime", bTime) :
                new ObjectParameter("bTime", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PR_getStuffExpirationDate_Result>("PR_getStuffExpirationDate", aTimeParameter, bTimeParameter);
        }
    
        public virtual ObjectResult<PR_MaxAVGStuff_Result> PR_MaxAVGStuff()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PR_MaxAVGStuff_Result>("PR_MaxAVGStuff");
        }
    
        public virtual ObjectResult<PR_MinAVGStuff_Result> PR_MinAVGStuff()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PR_MinAVGStuff_Result>("PR_MinAVGStuff");
        }
    
        public virtual int PR_SetLevelDiscount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PR_SetLevelDiscount");
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
