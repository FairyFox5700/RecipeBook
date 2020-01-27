using GalaSoft.MvvmLight.Command;
using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeBook.ViewModels
{
   public class ItemViewModel:ViewModelBase, IPageViewModel
    {
        
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

            private ImageView selectedImageOfRecipe;
            public ImageView SelectedImageOfRecipe
            {
            get
            {
                return selectedImageOfRecipe;
            }
            set
            {
                selectedImageOfRecipe = value;
                OnPropertyChanged("SelectedImageOfRecipe");

            }
        }
        public ObservableCollection<ImageView> ImagesViewsCollection { get; }
        public ObservableCollection<string> CurrentRecipeInstructions { get; }

        public struct ImageView
        {
           public string ImagePath { get; set; }
           public string ItemDescription { get; set; }
        }
        public ItemViewModel(Recipe recipe)
        {
            SelectedRecipe = recipe;
            
                if (selectedRecipe != null)
                {
                    var images = SelectedRecipe.ImagePathes.ToList();
                    var listOfImagesView = new ObservableCollection<ImageView>();
                    foreach (var image in images)
                    {
                        var newImgeView = new ImageView { ImagePath = image.ImagePath, ItemDescription = String.Format("Шаг {0}", images.IndexOf(image)) };
                        listOfImagesView.Add(newImgeView);
                    }
                    this.ImagesViewsCollection = listOfImagesView;
                    var instructions = SelectedRecipe.Instruction.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    this.CurrentRecipeInstructions = new ObservableCollection<string>(instructions);
            
                
            }
            
           
        }
    }
}
