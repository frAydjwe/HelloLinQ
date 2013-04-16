using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace atelier5.ViewModel
{
 /*let age = DateTime.Now - emp.Birth_Date.Value.Year*/
    public class MaVueModel1 : INotifyPropertyChanged
    {


        private int _selectedFilter = 0;
        private readonly string[] _filters;
        private Model.EntrepriseEntities _context;
        public MaVueModel1(Model.EntrepriseEntities context)
        {
            _context = context;
            _filters = "Tout le staff,10$ et moins,Anniversaires,Anniversaires ordre croissant,Commandes françaises".Split(',');
        }
        public IEnumerable<object> FilteredList
        {
            get
            {
               
                switch (this._selectedFilter)
                {
                    case 0:
                        return from employee in _context.Employees
                               select new
                               {
                                   Prénom = employee.First_Name,
                                   Nom = employee.Last_Name
                               };
                    case 1:
                        return from product in _context.Products
                               where product.Unit_Price < 10.0m
                               select new
                               {
                                   Produit = product.Product_Name,
                                   Prix = product.Unit_Price
                               };
                    case 2 :
                        return from employee in _context.Employees
                               let bd = employee.Birth_Date.Value
                               where bd.Month == 01
                               select new
                               {
                                   Prénom = employee.First_Name,
                                   Nom = employee.Last_Name,
                                   JourDeNaissance = bd.Day,
                                   DateDeNaissance = bd
                               };
                    case 3:
                        return from employee in _context.Employees
                               let bd = employee.Birth_Date.Value
                               orderby bd
                               select new
                               {
                                   Prénom = employee.First_Name,
                                   Nom = employee.Last_Name,
                                   JourDeNaissance = bd.Day,
                                   DateDeNaissance = bd
                               };

                    case 4:
                        return from customers in _context.Customers
                               let nbCmde = customers.Orders.Count()
                               select new
                               {
                                   Prénom = customers.Contact_Name,
                                   Commandes = nbCmde
   
                               };
                    default:
                        return new string[] {
"(Not implemented filter)"
};
                }
            }
        }
        public IEnumerable<String> Filters
        {
            get { return _filters; }
        }
        public int SelectedFilter
        {
            get { return this._selectedFilter; }
            set
            {
                this._selectedFilter = value;
                if (PropertyChanged != null)
                    PropertyChanged(this,
                    new PropertyChangedEventArgs("FilteredList")
                    );
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }



}
