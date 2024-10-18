using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CustomForwardRenderer : ScriptableRendererFeature
{
    class CustomRenderPass : ScriptableRenderPass
    {
        public Material postProcessMaterial;

        private RenderTargetIdentifier currentTarget;

        public void Setup(RenderTargetIdentifier source)
        {
            this.currentTarget = source;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (postProcessMaterial == null)
            {
                Debug.LogWarning("No post-process material assigned.");
                return;
            }

            CommandBuffer cmd = CommandBufferPool.Get("ColdEffectPostProcess");

            // Aplica el material al render target actual
            Blit(cmd, currentTarget, currentTarget, postProcessMaterial);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }

    CustomRenderPass m_ScriptablePass;
    public Material postProcessMaterial;

    public override void Create()
    {
        m_ScriptablePass = new CustomRenderPass();

        // Ejecuta el renderizado después de que se hayan renderizado las transparencias
        m_ScriptablePass.renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (postProcessMaterial != null)
        {
            m_ScriptablePass.Setup(renderer.cameraColorTarget);
            m_ScriptablePass.postProcessMaterial = postProcessMaterial;
            renderer.EnqueuePass(m_ScriptablePass);
        }
    }
}


