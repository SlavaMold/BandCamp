using System.Collections.Generic;
using System.Text;
using BandCamp.Models;

namespace BandCamp.Patterns.Creational
{
    // ---- Конкретные продукты — текстовые отчёты ----

    public class TextMembersReport : IReport
    {
        private readonly List<Member> _members;
        public string Title => "Отчёт по участникам (текст)";

        public TextMembersReport(List<Member> members)
        {
            _members = members;
        }

        public string Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine("================================");
            sb.AppendLine("       УЧАСТНИКИ ГРУППЫ        ");
            sb.AppendLine("================================");
            sb.AppendLine($"{"Имя",-25} {"Роль",-20} {"Опыт",-8} {"Активен"}");
            sb.AppendLine(new string('-', 65));
            foreach (var m in _members)
                sb.AppendLine($"{m.FullName,-25} {m.Role,-20} {m.ExperienceYears,-8} {(m.IsActive ? "Да" : "Нет")}");
            sb.AppendLine($"\nВсего участников: {_members.Count}");
            return sb.ToString();
        }
    }

    public class TextConcertsReport : IReport
    {
        private readonly List<Concert> _concerts;
        public string Title => "Отчёт по концертам (текст)";

        public TextConcertsReport(List<Concert> concerts)
        {
            _concerts = concerts;
        }

        public string Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine("================================");
            sb.AppendLine("          КОНЦЕРТЫ             ");
            sb.AppendLine("================================");
            sb.AppendLine($"{"Название",-25} {"Группа",-20} {"Дата",-12} {"Оплата"}");
            sb.AppendLine(new string('-', 70));
            foreach (var c in _concerts)
                sb.AppendLine($"{c.Name,-25} {c.BandName,-20} {c.Date:dd.MM.yyyy,-12} {c.Payment:F2}$");
            sb.AppendLine($"\nВсего концертов: {_concerts.Count}");
            return sb.ToString();
        }
    }

    public class TextContractsReport : IReport
    {
        private readonly List<Contract> _contracts;
        public string Title => "Отчёт по контрактам (текст)";

        public TextContractsReport(List<Contract> contracts)
        {
            _contracts = contracts;
        }

        public string Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine("================================");
            sb.AppendLine("          КОНТРАКТЫ            ");
            sb.AppendLine("================================");
            sb.AppendLine($"{"Продукт",-25} {"Группа",-20} {"Тип",-12} {"Оплата"}");
            sb.AppendLine(new string('-', 70));
            foreach (var c in _contracts)
                sb.AppendLine($"{c.ProductName,-25} {c.BandName,-20} {c.Type,-12} {c.Payment:F2}$");
            sb.AppendLine($"\nВсего контрактов: {_contracts.Count}");
            return sb.ToString();
        }
    }

    // ---- Конкретная фабрика — текстовый формат ----

    public class TextReportFactory : IReportFactory
    {
        public IReport CreateMembersReport(List<Member> members) =>
            new TextMembersReport(members);

        public IReport CreateConcertsReport(List<Concert> concerts) =>
            new TextConcertsReport(concerts);

        public IReport CreateContractsReport(List<Contract> contracts) =>
            new TextContractsReport(contracts);
    }
}