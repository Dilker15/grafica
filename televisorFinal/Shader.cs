using System;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Grafica_Project.Negocio
{
    class Shader
    {
      

        int id; 
        private bool disposedValue = false;

       
        public Shader(string vertexPath, string fragmentPath)
        {
            int vertexShader, fragmentShader; 

          
            string vertexShaderSource;
            using (StreamReader reader = new StreamReader(vertexPath))
            {
                vertexShaderSource = reader.ReadToEnd();
            }

            string fragmentShaderSource;
            using (StreamReader reader = new StreamReader(fragmentPath))
            {
                fragmentShaderSource = reader.ReadToEnd();
            }

            
            vertexShader = compileShader(ShaderType.VertexShader, vertexShaderSource);
            fragmentShader = compileShader(ShaderType.FragmentShader, fragmentShaderSource);

            
            id = GL.CreateProgram();

            GL.AttachShader(id, vertexShader);
            GL.AttachShader(id, fragmentShader);
            GL.LinkProgram(id);

           
            GL.DetachShader(id, vertexShader);
            GL.DetachShader(id, fragmentShader);
            GL.DeleteShader(fragmentShader);
            GL.DeleteShader(vertexShader);
        }

        private int compileShader(ShaderType type, string source)
        {
            int shader = GL.CreateShader(type); 
            GL.ShaderSource(shader, source);
            GL.CompileShader(shader); 

           
            string infoLogVert = GL.GetShaderInfoLog(shader);
            if (infoLogVert != System.String.Empty)
                System.Console.WriteLine(infoLogVert);

            return shader;
        }


        public void use()
        {
            GL.UseProgram(id);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                GL.DeleteProgram(id);

                disposedValue = true;
            }
        }

        ~Shader()
        {
            GL.DeleteProgram(id);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
