using System;

namespace lab4_5
{
    //public class DeleteProductCommand : IProductCommand
    //{
    //    private readonly MainWindowViewModel _viewModel;

    //    public DeleteProductCommand(MainWindowViewModel viewModel)
    //    {
    //        _viewModel = viewModel;
    //    }

    //    public event EventHandler CanExecuteChanged;

    //    public bool CanExecute(object parameter)
    //    {
    //        return parameter is Product && _viewModel.CurrentUser?.Role == "Admin";
    //    }

    //    public void Execute(object parameter)
    //    {
    //        if (parameter is Product product)
    //        {
    //            Execute(product);
    //        }
    //    }

    //    public void Execute(Product product)
    //    {
    //        _viewModel.DeleteProduct(product);
    //    }
    //}
}