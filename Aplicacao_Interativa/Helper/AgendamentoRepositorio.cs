﻿using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Aplicacao_Interativa.Helper
{
    public class AgendamentoRepositorio : IAgendamentoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public AgendamentoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public AgendamentoModel Adicionar(AgendamentoModel agendamento)
        {
            _bancoContext.Agendamentos.Add(agendamento);
            _bancoContext.SaveChanges();

            return agendamento;
        }
        public List<ServicoModel> BuscarServicos()
        {
            return _bancoContext.Servicos.ToList();
        }
        public List<HorarioModel> BuscarHorarios()
        {
            return _bancoContext.Horarios.ToList();
        }
        public AgendamentoModel BuscarPorData(DateTime data, int horarioId)
        {
            return _bancoContext.Agendamentos.FirstOrDefault(x => x.DataAgendamento == data && x.HorarioId == horarioId);
        }
        public List<HorarioModel> BuscarHorariosDisponiveis(DateTime data)
        {
            var horariosDisponiveis = _bancoContext.Horarios.ToList();
            var agendamentosDoDia = _bancoContext.Agendamentos.Where(a => a.DataAgendamento.Date == data.Date).ToList();

            foreach (var agendamento in agendamentosDoDia)
            {
                horariosDisponiveis.RemoveAll(h => h.Id == agendamento.HorarioId);
            }
            return horariosDisponiveis;
        }

        public string BuscarServicoPeloId(int id)
        {
            List<ServicoModel> listaServicos = BuscarServicos();

            foreach (ServicoModel servicos in listaServicos)
            {
                if (servicos.Id == id)
                {
                    return servicos.Nome;
                }
            }
            return "serviço";
        }

        public string BuscarHorarioPeloId(int id)
        {
            List<HorarioModel> listaHorarios = BuscarHorarios();

            foreach (HorarioModel horario in listaHorarios)
            {
                if(horario.Id == id)
                {
                    return horario.Horario;
                }
            }

            return "00:00";
        }
    }
}
