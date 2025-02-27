using ExamenP3_RiveraJoel.Models;
using Microsoft.AspNetCore.Mvc;
using ExamenP3_RiveraJoel.Data;

namespace ExamenP3_RiveraJoel.Controllers
{
    public class Prueba : Controller
    {

        private readonly OpinionesClienteDataAccessLayer _clienteDAL = new OpinionesClienteDataAccessLayer();

        public IActionResult Index()
        {
            List<OpinionesClientes> opiniones = _clienteDAL.GetOpiniones();
            return View(opiniones);
        }

        public IActionResult Create()
        {
            return View();
        }

        // Procesar la creación de un cliente
        [HttpPost]
        public IActionResult Create(OpinionesClientes opinion)
        {
            if (ModelState.IsValid)
            {
                _clienteDAL.AddOpinion(opinion);
                return RedirectToAction("Index");
            }
            return View(opinion);
        }

        // Mostrar detalles de un cliente
        public IActionResult Details(int id)
        {
            OpinionesClientes opinion = _clienteDAL.GetOpinionByID(id);
            if (opinion == null)
                return NotFound();
            return View(opinion);
        }

        // Mostrar formulario para editar un cliente
        public IActionResult Edit(int id)
        {
            OpinionesClientes opinion = _clienteDAL.GetOpinionByID(id);
            if (opinion == null)
                return NotFound();
            return View(opinion);
        }

        // Procesar la edición de un cliente
        [HttpPost]
        public IActionResult Edit(OpinionesClientes opinion)
        {
            if (ModelState.IsValid)
            {
                _clienteDAL.UpdateOpinion(opinion);
                return RedirectToAction("Index");
            }
            return View(opinion);
        }

        // GET: Cliente/Delete/9
        public IActionResult Delete(int id)
        {
            OpinionesClientes opinion = _clienteDAL.GetOpiniones().FirstOrDefault(c => c.OpinionID == id);
            if (opinion == null)
            {
                return NotFound();
            }
            return View(opinion);
        }

        // POST: Cliente/Delete/9
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _clienteDAL.DeleteOpinion(id);
            return RedirectToAction("Index");
        }
    }
}
