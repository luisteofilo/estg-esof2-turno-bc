using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Frontend.Components.Pages;

public partial class DeleteThis
{
    private int variavel = 0;

    /* não funciona
    protected override void OnInitialized()
    {
        try
        {
            PostNumber = 5;
            variavel = PostNumber;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in OnInitialized: {ex.Message}");
        }
    }
    */
    [Parameter] public string PostString { get; set; }
    [Parameter] public int PostNumber { get; set; } = 5;
    [Parameter] public int Incrementp { get; set; } = 1;

    private string texto = "";
    private string divText = "Mouse out";

    private void Incrementar()
    {
        variavel= variavel + Incrementp;
    }

    private void OnChange(ChangeEventArgs e)
    {
        texto = (string)e.Value!;
    }

    private void OnInput(ChangeEventArgs e) => texto = (string)e.Value!;

    private void MouseOver(MouseEventArgs e) => divText = "Mouse over";

    private void MouseOut(MouseEventArgs e) => divText = "Mouse out";

    private void OnClickClear()
    {
        texto = "";
    }

    private string searchResult = "";
    async Task Search()
    {
        searchResult = "Searching...";
        //só simular ir à base de dados
        await Task.Delay(2000);
        searchResult = $"Found {Random.Shared.Next()} results";
    }
}