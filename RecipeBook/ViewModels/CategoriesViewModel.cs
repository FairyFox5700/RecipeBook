using GalaSoft.MvvmLight.Messaging;
using RecipeBook.Commands;
using RecipeBook.DataAccess;
using RecipeBook.Models;
using RecipeBook.Paging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeBook.ViewModels
{
   public class CategoriesViewModel:ViewModelBase, IPageViewModel
    {
        CookDbContext context;
        private ICommand goToRecipes;

        public ICommand GoToRecipes
        {
            get
            {
                return
             goToRecipes ?? (goToRecipes = new RelayCommand(x =>
             {
                 
                 Mediator.Notify("GoToRecipeView", SelectedCategory);
             }));
            }
        }
        public ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }

        private Category selectedCategory;
        public Category SelectedCategory
        {
            get {
               
                return selectedCategory; }
            set
            {
              
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");

            }
        }
     


        public CategoriesViewModel()
        {
            context = new DataAccess.CookDbContext();
         
                var categories = context.Categories.Include(x => x.Recipes).ToList();
                Categories = new ObservableCollection<Category>(categories);
          
           
        }
    }
}
