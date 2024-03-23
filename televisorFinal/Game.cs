using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Grafica_Project.Negocio;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;

namespace televisorFinal
{
    public class Game : GameWindow
    {
       
        int VertexBufferObject;
        int VertexArrayObject;
        int IndexBufferObject;
        Television tv = new Television();
        Shader shader;

     

        public Game():base(GameWindowSettings.Default,NativeWindowSettings.Default)
        {
            startProyect();
        }


        public void startProyect() {
            VertexArrayObject = GL.GenVertexArray(); 
            VertexBufferObject = GL.GenBuffer();
            IndexBufferObject = GL.GenBuffer();

            GL.BindVertexArray(VertexArrayObject); 
           // GL.Enable(EnableCap.DepthTest);


            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, tv.cantidadVertices() * sizeof(float), tv.getVertices(), BufferUsageHint.StaticDraw);

            
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, tv.cantidadIndices() * sizeof(uint), tv.getIndices(), BufferUsageHint.StaticDraw);

           
            string vertexPath = "shaders/VertexShader.glsl";
            string fragmentPath = "shaders/FragmentShader.glsl";

            shader = new Shader(vertexPath, fragmentPath);

           /* projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f),500 / (float)600, 0.1f, 100f);
            viewMatrix = Matrix4.LookAt(new Vector3(0, 0, 3), Vector3.Zero, Vector3.UnitY);*/
        }



       
        protected override void OnLoad()
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
           



            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, sizeof(float) * 3, 0);
            GL.EnableVertexAttribArray(0);

            shader.use();

            base.OnLoad();
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            shader.use();

            /*int projectionMatrixLocation = GL.GetUniformLocation(IndexBufferObject,"projection");
            GL.UniformMatrix4(projectionMatrixLocation, false, ref projectionMatrix);

            int viewMatrixLocation = GL.GetUniformLocation(IndexBufferObject, "view");
            GL.UniformMatrix4(viewMatrixLocation, false, ref viewMatrix);
            */


            GL.BindVertexArray(VertexArrayObject);
            GL.DrawElements(PrimitiveType.Lines, tv.cantidadIndices(), DrawElementsType.UnsignedInt, 0);
           
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }




        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);

        }

       
        protected override void OnUnload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0); 
            GL.DeleteBuffer(VertexBufferObject); 
            shader.Dispose(); 
            base.OnUnload();
        }
    }
}
