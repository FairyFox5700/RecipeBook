using GalaSoft.MvvmLight.Messaging;
using RecipeBook.Commands;
using RecipeBook.DataAccess;
using RecipeBook.Models;
using RecipeBook.Paging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeBook.ViewModels
{
    public class RecipesViewModel:ViewModelBase, IPageViewModel
    {
        CookDbContext context;
        private ICommand goToItem;

        public ICommand GoToItem
        {
            get
            {
                return
             goToItem ?? (goToItem = new RelayCommand(x =>
             {

                 Mediator.Notify("GoToItemView",SelectedRecipe);
             }));
            }
        }
        public ObservableCollection<Recipe> recipes;
        public ObservableCollection<Recipe> Recipes
        {
            get => recipes;
            set
            {
                recipes = value;
                OnPropertyChanged("Recipes");
            }
        }
        private Recipe selectedRecipe;
        public Recipe SelectedRecipe
        {
            get
            {

                return selectedRecipe;
            }
            set
            {

                selectedRecipe = value;
                OnPropertyChanged("SelectedRecipe");

            }
        }
        private Category selectedCategory;
        public Category SelectedCategory
        {
            get
            {

                return selectedCategory;
            }
            set
            {

                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");

            }
        }


        public RecipesViewModel(Category category)
        {
            if(category!=null)
            {
                SelectedCategory = category;
                var recipes = category.Recipes;
                Recipes = new ObservableCollection<Recipe>(recipes);
       
            }
           
        }
    }

}
