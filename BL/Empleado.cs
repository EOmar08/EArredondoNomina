using System.Collections.Generic;
using System.Globalization;

namespace BL
{
    public class Empleado
    {

        private readonly DL.ProyectoNominaContext _context;

        public Empleado(DL.ProyectoNominaContext context)
        {
            _context = context;
        }

        public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                var listaEmpleados = (from empleadoDB in _context.Empleados
                                      select empleadoDB).ToList();

                if (listaEmpleados.Count > 0)
                {
                    result.Objects = new List<object>();
                    foreach (var empleadoDB in listaEmpleados)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.IdEmpleado = empleadoDB.IdEmpleado;
                        empleado.Nombre = empleadoDB.Nombre;
                        empleado.ApellidoPaterno = empleadoDB.ApellidoPaterno;
                        empleado.ApellidoMaterno = empleadoDB.ApellidoMaterno;
                        //empleado.FechaNacimiento = DateTime.ParseExact(empleadoDB.FechaNacimiento.ToString(), "M/d/yyyy", CultureInfo.InvariantCulture);
                        empleado.FechaIngreso = empleadoDB.FechaIngreso.ToDateTime(TimeOnly.MinValue);
                        empleado.RFC = empleadoDB.Rfc;
                        empleado.NSS = empleadoDB.Nss;
                        empleado.CURP = empleadoDB.Curp;
                        empleado.FechaIngreso = empleadoDB.FechaIngreso.ToDateTime(TimeOnly.MinValue);
                        empleado.SalarioBase = empleadoDB.SalarioBase;
                        empleado.NoFaltas = empleadoDB.NoFaltas.Value;

                        empleado.Departamento = new ML.Departamento();
                        empleado.Departamento.IdDepartamento = empleadoDB.IdDepartamento;

                        result.Objects.Add(empleado);
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontraron registros";
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public ML.Result Add(ML.Empleado Empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                DL.Empleado empleadoAdd = new DL.Empleado();
                empleadoAdd.Nombre = Empleado.Nombre;
                empleadoAdd.ApellidoPaterno = Empleado.ApellidoPaterno;
                empleadoAdd.ApellidoMaterno = Empleado.ApellidoMaterno;
                empleadoAdd.FechaNacimiento = DateOnly.FromDateTime(Empleado.FechaNacimiento);
                empleadoAdd.Rfc = Empleado.RFC;
                empleadoAdd.Nss = Empleado.NSS;
                empleadoAdd.Curp = Empleado.CURP;
                empleadoAdd.FechaIngreso = DateOnly.FromDateTime(Empleado.FechaIngreso);
                empleadoAdd.IdDepartamento = Empleado.Departamento.IdDepartamento;
                empleadoAdd.SalarioBase = Empleado.SalarioBase;
                empleadoAdd.NoFaltas = Empleado.NoFaltas;

                _context.Empleados.Add(empleadoAdd);
                int rowsAffected = _context.SaveChanges();

                if (rowsAffected > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se insertó el registro";
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public ML.Result Update(ML.Empleado Empleado)
        {
            ML.Result result = new ML.Result();
            try
            {

                var empleadoUpdate = (from empleadoDB in _context.Empleados
                                      where empleadoDB.IdEmpleado == empleadoDB.IdEmpleado
                                      select empleadoDB).FirstOrDefault();

                if (empleadoUpdate != null)
                {
                    empleadoUpdate.Nombre = Empleado.Nombre;
                    empleadoUpdate.ApellidoPaterno = Empleado.ApellidoPaterno;
                    empleadoUpdate.ApellidoMaterno = Empleado.ApellidoMaterno;
                    empleadoUpdate.FechaNacimiento = DateOnly.FromDateTime(Empleado.FechaNacimiento);
                    empleadoUpdate.Rfc = Empleado.RFC;
                    empleadoUpdate.Nss = Empleado.NSS;
                    empleadoUpdate.Curp = Empleado.CURP;
                    empleadoUpdate.FechaIngreso = DateOnly.FromDateTime(Empleado.FechaIngreso);
                    empleadoUpdate.IdDepartamento = Empleado.Departamento.IdDepartamento;
                    empleadoUpdate.SalarioBase = Empleado.SalarioBase;
                    empleadoUpdate.NoFaltas = Empleado.NoFaltas;

                    int rowsAffected = _context.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el registro";
                    }
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontró el registro a actualizar";
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {

                var empleadoObj = (from empleadoDB in _context.Empleados
                                   where empleadoDB.IdEmpleado == IdEmpleado
                                   select empleadoDB).FirstOrDefault();
                if (empleadoObj != null)
                {
                    ML.Empleado empleado = new ML.Empleado();
                    empleado.IdEmpleado = empleadoObj.IdEmpleado;
                    empleado.Nombre = empleadoObj.Nombre;
                    empleado.ApellidoPaterno = empleadoObj.ApellidoPaterno;
                    empleado.ApellidoMaterno = empleadoObj.ApellidoMaterno;
                    empleado.FechaNacimiento = DateTime.ParseExact(empleadoObj.FechaNacimiento.ToString(), "M/d/yyyy", CultureInfo.InvariantCulture);
                    empleado.RFC = empleadoObj.Rfc;
                    empleado.NSS = empleadoObj.Nss;
                    empleado.CURP = empleadoObj.Curp;
                    empleado.FechaIngreso = DateTime.ParseExact(empleadoObj.FechaIngreso.ToString(), "M/d/yyyy", CultureInfo.InvariantCulture);
                    empleado.SalarioBase = empleadoObj.SalarioBase;
                    empleado.NoFaltas = empleadoObj.NoFaltas.Value;
                    empleado.Departamento = new ML.Departamento();
                    empleado.Departamento.IdDepartamento = empleadoObj.IdDepartamento;
                    result.Object = empleado;
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontró el registro";
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {

                var empleadoObj = (from empleadoDB in _context.Empleados
                                   where empleadoDB.IdEmpleado == IdEmpleado
                                   select empleadoDB).FirstOrDefault();
                if (empleadoObj != null)
                {
                    _context.Remove(empleadoObj);
                    int rowsAffected = _context.SaveChanges();
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontró el registro";
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
