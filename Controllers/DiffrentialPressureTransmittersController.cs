using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tenchex.Models;

namespace Tenchex.Controllers
{
    public class DiffrentialPressureTransmittersController : Controller
    {
        private readonly TenchexContext _context;

        public DiffrentialPressureTransmittersController(TenchexContext context)
        {
            _context = context;
        }

        // GET: DiffrentialPressureTransmitters
        public async Task<IActionResult> Index()
        {
              return _context.diffrentialPressureTransmitters != null ? 
                          View(await _context.diffrentialPressureTransmitters.ToListAsync()) :
                          Problem("Entity set 'TenchexContext.diffrentialPressureTransmitters'  is null.");
        }

        // GET: DiffrentialPressureTransmitters/Details/5
        public async Task<IActionResult> Details(Instrumentations ins)
        {
            if (ins == null || _context.diffrentialPressureTransmitters == null)
            {
                return NotFound();
            }

            DiffrentialPressureTransmitter? diffrentialPressureTransmitter = await _context.diffrentialPressureTransmitters
                .FirstOrDefaultAsync(m => m.DiffrentialPressureTransmitterId == ins.DiffrentialPressureTransmitterId);
            if (diffrentialPressureTransmitter == null)
            {
                return NotFound();
            }

            return View(diffrentialPressureTransmitter);
        }

        // GET: DiffrentialPressureTransmitters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiffrentialPressureTransmitters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiffrentialPressureTransmitterId,Kks,ModelNumber,AreaClassification,Ip,ElementMaterial,HousingMaterial,ProcessConnectionMaterial,SpanRange,CallibrationRange,SensorType,Accuracy,Repeatabilty,Standard,Lcd,KeyPad,Protocol,_420mA,Installation,MountingBracket,MountingBracketMaterial,Manifold,ManifoldType,ManifoldMaterial,DiaphragmSeal,DiaphragmSealMaterial,CabillaryTubes,CabillaryTubesMaterial")] DiffrentialPressureTransmitter diffrentialPressureTransmitter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diffrentialPressureTransmitter);
                await _context.SaveChangesAsync();
                return RedirectToAction("Set" , diffrentialPressureTransmitter);
            }
            return View(diffrentialPressureTransmitter);
        }

		public async Task<IActionResult> Set(DiffrentialPressureTransmitter diffrentialPressureTransmitter)
		{
			Instrumentations instrumentations = new()
			{
				DiffrentialPressureTransmitterId = diffrentialPressureTransmitter.DiffrentialPressureTransmitterId,
				InstrumentType = InstrumentType.DPTransmitter
			};
			_context.Add(instrumentations);
			await _context.SaveChangesAsync();
			Types type = new()
			{
				InstrumentId = instrumentations.InstrumentationId
			};
			_context.Add(type);
			await _context.SaveChangesAsync();
			return RedirectToAction("Create", "Equipments", type);
		}
		// GET: DiffrentialPressureTransmitters/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.diffrentialPressureTransmitters == null)
            {
                return NotFound();
            }

            var diffrentialPressureTransmitter = await _context.diffrentialPressureTransmitters.FindAsync(id);
            if (diffrentialPressureTransmitter == null)
            {
                return NotFound();
            }
            return View(diffrentialPressureTransmitter);
        }

        // POST: DiffrentialPressureTransmitters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiffrentialPressureTransmitterId,Kks,ModelNumber,AreaClassification,Ip,ElementMaterial,HousingMaterial,ProcessConnectionMaterial,SpanRange,CallibrationRange,SensorType,Accuracy,Repeatabilty,Standard,Lcd,KeyPad,Protocol,_420mA,Installation,MountingBracket,MountingBracketMaterial,Manifold,ManifoldType,ManifoldMaterial,DiaphragmSeal,DiaphragmSealMaterial,CabillaryTubes,CabillaryTubesMaterial")] DiffrentialPressureTransmitter diffrentialPressureTransmitter)
        {
            if (id != diffrentialPressureTransmitter.DiffrentialPressureTransmitterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diffrentialPressureTransmitter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiffrentialPressureTransmitterExists(diffrentialPressureTransmitter.DiffrentialPressureTransmitterId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(diffrentialPressureTransmitter);
        }

        // GET: DiffrentialPressureTransmitters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.diffrentialPressureTransmitters == null)
            {
                return NotFound();
            }

            var diffrentialPressureTransmitter = await _context.diffrentialPressureTransmitters
                .FirstOrDefaultAsync(m => m.DiffrentialPressureTransmitterId == id);
            if (diffrentialPressureTransmitter == null)
            {
                return NotFound();
            }

            return View(diffrentialPressureTransmitter);
        }

        // POST: DiffrentialPressureTransmitters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.diffrentialPressureTransmitters == null)
            {
                return Problem("Entity set 'TenchexContext.diffrentialPressureTransmitters'  is null.");
            }
            var diffrentialPressureTransmitter = await _context.diffrentialPressureTransmitters.FindAsync(id);
            if (diffrentialPressureTransmitter != null)
            {
                _context.diffrentialPressureTransmitters.Remove(diffrentialPressureTransmitter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiffrentialPressureTransmitterExists(int id)
        {
          return (_context.diffrentialPressureTransmitters?.Any(e => e.DiffrentialPressureTransmitterId == id)).GetValueOrDefault();
        }
    }
}
