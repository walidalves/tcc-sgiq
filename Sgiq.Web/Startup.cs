using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sgiq.Negocio;
using Sgiq.Negocio.Servicos;
using Sgiq.Dados;

namespace Sgiq
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SGIQContext>();
            services.AddMvc();
            services.AddRouting();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            /* Inclusão de Dados das tabelas auxiliares */
            CriarTabelasAuxiliares();
        }

        private void CriarTabelasAuxiliares()
        {
            var condicaoBo = new CondicaoBo();
            condicaoBo.Criar();

            var papelBO = new PapelBo();
            papelBO.Criar();

            var situacaoProjetoBo = new SituacaoProjetoBo();
            situacaoProjetoBo.Criar();

            var tipoDadoBo = new TipoDadoBo();
            tipoDadoBo.Criar();

            var tipoRequisitoBo = new TipoRequisitoBo();
            tipoRequisitoBo.Criar();

            var frequenciaAfericaoBo = new FrequenciaAfericaoBo();
            frequenciaAfericaoBo.Criar();
        }
    }
}
