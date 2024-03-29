﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankingSystem
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BankingSystemDBEntities : DbContext
    {
        public BankingSystemDBEntities()
            : base("name=BankingSystemDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
    
        public virtual int CreateAccount(Nullable<int> clientID, Nullable<decimal> initialAmount)
        {
            var clientIDParameter = clientID.HasValue ?
                new ObjectParameter("ClientID", clientID) :
                new ObjectParameter("ClientID", typeof(int));
    
            var initialAmountParameter = initialAmount.HasValue ?
                new ObjectParameter("InitialAmount", initialAmount) :
                new ObjectParameter("InitialAmount", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateAccount", clientIDParameter, initialAmountParameter);
        }
    
        public virtual int CreateClient(string firstName, string fatherName, string lastName, string motherName, Nullable<System.DateTime> dOB, string placeOfBirth, string idNumber)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var fatherNameParameter = fatherName != null ?
                new ObjectParameter("FatherName", fatherName) :
                new ObjectParameter("FatherName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var motherNameParameter = motherName != null ?
                new ObjectParameter("MotherName", motherName) :
                new ObjectParameter("MotherName", typeof(string));
    
            var dOBParameter = dOB.HasValue ?
                new ObjectParameter("DOB", dOB) :
                new ObjectParameter("DOB", typeof(System.DateTime));
    
            var placeOfBirthParameter = placeOfBirth != null ?
                new ObjectParameter("PlaceOfBirth", placeOfBirth) :
                new ObjectParameter("PlaceOfBirth", typeof(string));
    
            var idNumberParameter = idNumber != null ?
                new ObjectParameter("IdNumber", idNumber) :
                new ObjectParameter("IdNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateClient", firstNameParameter, fatherNameParameter, lastNameParameter, motherNameParameter, dOBParameter, placeOfBirthParameter, idNumberParameter);
        }
    
        public virtual int CreateTransaction(string type, Nullable<System.DateTime> date, Nullable<int> employeeId, Nullable<int> clientID, Nullable<decimal> amount)
        {
            var typeParameter = type != null ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(string));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("Date", date) :
                new ObjectParameter("Date", typeof(System.DateTime));
    
            var employeeIdParameter = employeeId.HasValue ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(int));
    
            var clientIDParameter = clientID.HasValue ?
                new ObjectParameter("ClientID", clientID) :
                new ObjectParameter("ClientID", typeof(int));
    
            var amountParameter = amount.HasValue ?
                new ObjectParameter("Amount", amount) :
                new ObjectParameter("Amount", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateTransaction", typeParameter, dateParameter, employeeIdParameter, clientIDParameter, amountParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> GetAccountBalance(Nullable<int> clientID)
        {
            var clientIDParameter = clientID.HasValue ?
                new ObjectParameter("ClientID", clientID) :
                new ObjectParameter("ClientID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("GetAccountBalance", clientIDParameter);
        }
    }
}
