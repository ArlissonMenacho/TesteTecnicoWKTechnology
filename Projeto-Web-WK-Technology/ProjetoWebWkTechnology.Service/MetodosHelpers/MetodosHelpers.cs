using ProjetoWebWkTechnology.Domain.Entities;
using System.Web.Mvc;

namespace ProjetoWebWkTechnology.Service.MetodosHelpers
{
    //Infelizmente não consegui implementar na controller
    //ficou dando erro de cast acredito que seja algum tipo de bug
    public static class MetodosHelpers
    {
        #region MetodosAuxiliares
        public static SelectList MontaSelectListItem(List<Categoria> categorias, CancellationToken cancellationToken)
        {
            var selectList = categorias.Select(c => new SelectListItem
            {
                Text = c.Nome,
                Value = c.Id.ToString()
            });
            var select = new SelectList(selectList, "Value", "Text");
            return select;
        }
        #endregion
    }
}
