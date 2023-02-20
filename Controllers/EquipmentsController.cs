using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tenchex.Models;
using Newtonsoft.Json;

namespace Tenchex.Controllers
{
	public class EquipmentsController : Controller
	{
		private readonly TenchexContext _context;

		public EquipmentsController(TenchexContext context)
		{
			_context = context;
		}

		//Select Equipments
		public IActionResult Select(int? Id)
		{
			TempData["SystemId"] = Id.ToString();
			return RedirectToAction("Index");
		}
		public IActionResult SelectEquipment()
		{
			return View();
		}

		public IActionResult SelectEquip(EquipmentType Id)
		{
			//TempData["EquipmentType"] = Id;

			switch (Id)
			{
				case EquipmentType.Instruments:
					return RedirectToAction("Send", "Instrumentations");
				case EquipmentType.Valves:
					return RedirectToAction("Create", "Valves");
				case EquipmentType.Pumps:
					return RedirectToAction("Create", "Pumps");
				case EquipmentType.Tanks:
					return RedirectToAction("Create", "Tanks");
				case EquipmentType.Compressors:
					return RedirectToAction("Create", "Compressors");
				case EquipmentType.Pipes:
					return RedirectToAction("Create", "Pipes");
				case EquipmentType.cables:
					return RedirectToAction("Create", "Cables");
				default:
					break;
			}

			return RedirectToAction("Create");
		}


		public IActionResult SelectType(int? Id)
		{
			Equipments? equipments = (from E in _context.Equipments
									  where Id == E.EquipmentId
									  select E
									 ).FirstOrDefault();
			Types? types = (from T in _context.Types
							join E in _context.Equipments on T.TypeId equals E.TypeId
							where T.TypeId == equipments.TypeId
							select T
						   ).FirstOrDefault();
			switch (equipments.Type)
			{
				case EquipmentType.Instruments:
					Instrumentations? ins = (from I in _context.Instrumentations
											 join T in _context.Types
											on I.InstrumentationId equals T.InstrumentId
											 where I.InstrumentationId == types.InstrumentId
											 select I
											).FirstOrDefault();
					return RedirectToAction("SelectInstrument", ins);

				case EquipmentType.Valves:
					break;
				case EquipmentType.Pumps:
					break;
				case EquipmentType.Tanks:
					break;
				case EquipmentType.Compressors:
					break;
				case EquipmentType.Pipes:
					break;
				case EquipmentType.cables:
					break;
				default:
					break;
			}

			return View();
		}

		public IActionResult SelectInstrument(Instrumentations ins)
		{
			int? InstrumID;
			switch (ins.InstrumentType)
			{

				case InstrumentType.PressureGauge:
					return RedirectToAction("Details", "PressureGauges" , ins);
				case InstrumentType.PressureTransmitter:
					InstrumID = ins.PressureTransmitterId;
					return RedirectToAction("Details", "PressureTransmitters", ins);
				case InstrumentType.DPGauge:
					return RedirectToAction("Details", "DiffrentialPressureGauges", ins);
				case InstrumentType.DPTransmitter:
					return RedirectToAction("Details", "DiffrentialPressureTransmitters", ins);
				case InstrumentType.TemperatureTransmitter:
					return RedirectToAction("Details", "TemperatureTransmitters", ins);
				case InstrumentType.TemperatureGauge:
					return RedirectToAction("Details", "TemperatureGauges", ins);
				default:
					break;
			}
			//throw new NotImplementedException();
			return View(ins);
		}

		// GET: Equipments
		public async Task<IActionResult> Index()
		{
			ViewData["EquipmentType"] = Enum.GetNames(typeof(EquipmentType));
			if (TempData.ContainsKey("SystemId"))
			{
				// query to return equipments for selected systems
#pragma warning disable CS8604 // Possible null reference argument.
				int Id = int.Parse(TempData["SystemId"].ToString());
#pragma warning restore CS8604 // Possible null reference argument.
				List<Equipments> Eq = (from E in _context.Equipments.Include(s => s.Systems)
									   where E.SystemId == Id
									   select E
									   ).ToList();
				TempData["SystemId"] = Id.ToString();


				// Vendor Name Query
				ViewData["VendorName"] = (from E in _context.Vendors
										  select E.VendorName
										  ).ToList();
				// Supplier Name Query
				ViewData["SupplierName"] = (from E in _context.Suppliers
											select E.SupplierName
										  ).ToList();
				// Employee Full Name Query
				ViewData["EmployeeName"] = (from E in _context.Employees
											select (E.FirstName + ' ' + E.LastName)
										  ).ToList();

				return _context.Equipments != null ?
						 View(Eq) :
						 Problem("Entity set 'TenchexContext.Equipments'  is null.");
			}
			return _context.Equipments != null ?
						View(await _context.Equipments.ToListAsync()) :
						Problem("Entity set 'TenchexContext.Equipments'  is null.");
		}

		// GET: Equipments/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Equipments == null)
			{
				return NotFound();
			}

			var equipments = await _context.Equipments
				.FirstOrDefaultAsync(m => m.EquipmentId == id);
			if (equipments == null)
			{
				return NotFound();
			}

			return View(equipments);
		}

		// GET: Equipments/Create
		public IActionResult Create(Types types)
		{
			TempData["TypeId"] = types.TypeId;
			ViewData["EquipmentType"] = new SelectList(Enum.GetNames(typeof(EquipmentType)));
			ViewData["EquipmentCurrency"] = new SelectList(Enum.GetNames(typeof(Currency)));
			ViewData["Vendors"] = new SelectList(_context.Vendors, "VendorID", "VendorName");
			ViewData["Suppliers"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName");
			ViewData["Employee"] = new SelectList(_context.Employees, "EmployeeId", "FirstName");
			return View();
		}

		// POST: Equipments/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("EquipmentId,Type,UnitePrice,Currency,Quantities,VendorID,SupplierId,EmployeeId,InstrumentationSpecID,SystemId")] Equipments equipments)
		{
			if (TempData["SystemId"] != null)
			{
#pragma warning disable CS8604 // Possible null reference argument.
				equipments.SystemId = int.Parse(TempData["SystemId"].ToString());
#pragma warning restore CS8604 // Possible null reference argument.
			}
			if (TempData["TypeId"] != null)
			{
#pragma warning disable CS8604 // Possible null reference argument.
				equipments.TypeId = int.Parse(TempData["TypeId"].ToString());
#pragma warning restore CS8604 // Possible null reference argument.
			}
			if (ModelState.IsValid)
			{
				_context.Add(equipments);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(equipments);
		}

		// GET: Equipments/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Equipments == null)
			{
				return NotFound();
			}

			var equipments = await _context.Equipments.FindAsync(id);
			if (equipments == null)
			{
				return NotFound();
			}
			return View(equipments);
		}

		// POST: Equipments/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("EquipmentId,Type,UnitePrice,Currency,Quantities,VendorID,SupplierId,EmployeeId,InstrumentationSpecID,SystemId")] Equipments equipments)
		{
			if (id != equipments.EquipmentId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(equipments);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!EquipmentsExists(equipments.EquipmentId))
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
			return View(equipments);
		}

		// GET: Equipments/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Equipments == null)
			{
				return NotFound();
			}

			var equipments = await _context.Equipments
				.FirstOrDefaultAsync(m => m.EquipmentId == id);
			if (equipments == null)
			{
				return NotFound();
			}

			return View(equipments);
		}

		// POST: Equipments/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Equipments == null)
			{
				return Problem("Entity set 'TenchexContext.Equipments'  is null.");
			}
			var equipments = await _context.Equipments.FindAsync(id);
			if (equipments != null)
			{
				_context.Equipments.Remove(equipments);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool EquipmentsExists(int id)
		{
			return (_context.Equipments?.Any(e => e.EquipmentId == id)).GetValueOrDefault();
		}
	}
}
