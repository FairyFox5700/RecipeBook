using GalaSoft.MvvmLight.Messaging;
using RecipeBook.Commands;
using RecipeBook.Models;
using RecipeBook.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RecipeBook.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ICommand changePageCommand;
        private IPageViewModel currentPageViewModel;
        private List<IPageViewModel> pageViewModels;

        public ICommand ChangePageCommand
        {
            get
            {
                if (changePageCommand == null)
                {
                    changePageCommand = new RelayCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return changePageCommand;
            }
        }
      
        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (pageViewModels == null)
                    pageViewModels = new List<IPageViewModel>();

                return pageViewModels;
            }
        }
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return currentPageViewModel;
            }
            set
            {
                if (currentPageViewModel != value)
                {
                    currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }


        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        private ICommand goToCategories;

        public ICommand GoToCategories
        {
            get  { return
                goToCategories ?? (goToCategories = new RelayCommand(x =>
                   {
                       Mediator.Notify("GoToCategoreScreen", "");


                   }));
            }
        }

        private void OnGoToCategoreScreen(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }
        private void OnGoToRecipeView(object obj)
        {
            if(obj!=null)
            {
                ChangeViewModel(new RecipesViewModel((Category)obj));
            }
            else
            {
                MessageBox.Show("Select  recipe first");
            }
           
        }
        private void OnGoToItemView(object obj)
        {
            if (obj != null)
            {
                ChangeViewModel(new ItemViewModel((Recipe)obj));
            }
            else
            {
                MessageBox.Show("Select  recipe first");
            }

        }
       

        public MainViewModel()
        {

            PageViewModels.Add(new CategoriesViewModel());
           // PageViewModels.Add(new RecipesViewModel());
            CurrentPageViewModel = PageViewModels[0];
            Mediator.Subscribe("GoToCategoreScreen", OnGoToCategoreScreen);
            Mediator.Subscribe("GoToRecipeView", OnGoToRecipeView);
            Mediator.Subscribe("GoToItemView", OnGoToItemView);

        }
    }
}
