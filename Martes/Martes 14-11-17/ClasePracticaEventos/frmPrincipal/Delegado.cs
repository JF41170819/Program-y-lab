using Entidades;
using System;
delegate void actualizarNombrePorDelegado(string message);
delegate void actualizarFotoPorDelegado(string path);
delegate void actualizarAlumno(Alumno alum, EventArgs evento);