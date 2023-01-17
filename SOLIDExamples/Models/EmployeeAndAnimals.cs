using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using Microsoft.Owin.Security;

namespace SOLIDExamples.Models
{
    //Single Responsibility Principle
    //Open Closed Principle
    //Liskov Substitution Principle
    //Interface Segregation Principle
    //Dependency Inversion Principle
    public abstract class Employee
    {
        private int  Id { get; set; }
        private string Name { get; set; }

        public virtual int CalculateSalary() => 1000;
    }


    public class PermanentEmployee : Employee
    {
        public override int CalculateSalary() => 30*1000;
    }

    public class ContractEmployee : Employee
    {
        public override int CalculateSalary() => 15*1000;
    }



    interface IAnimal
    {
        void Feed();
    }

    interface IPetAnimal : IAnimal
    {
        void Groom();
    }

    interface IWildAnimal: IAnimal
    {
        void Hunt();
    }



    public class Cow : IPetAnimal
    {
        public void Feed()
        {
            //fed a cow
        }

        public void Groom()
        {
            //groomed a cow 
        }
    }



    public class Doctor
    {
        private readonly IDoctorRepository _repository;

        public Doctor(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public void DoctorInfo(int id)
        {
            _repository.GetDoctor(id);
        }

        public void ConsultPatient()
        {
            _repository.ConsultPatient();
        }

        public void DeleteDoctor(int id)
        {
            _repository.DeleteDoctor(id);
        }

        public void WritePrescription()
        {
            _repository.WritePrescription();
        }

    }

    public interface IDoctorRepository
    {
        void ConsultPatient();
        void WritePrescription();
        void GetDoctor(int id);
        void DeleteDoctor(int id);
    }


    public class DoctorRepository : IDoctorRepository
    {
        public void ConsultPatient() { }

        public void WritePrescription() { }

        public void GetDoctor(int id) { }

        public void DeleteDoctor(int id) { }

    }
}