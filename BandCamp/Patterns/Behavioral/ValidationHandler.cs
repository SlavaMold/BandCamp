using BandCamp.Models;

namespace BandCamp.Patterns.Behavioral
{
    public abstract class ValidationHandler
    {
        protected ValidationHandler _next;

        public ValidationHandler SetNext(ValidationHandler next)
        {
            _next = next;
            return next;
        }

        public abstract string Handle(object model);
    }

    public class BandNameValidator : ValidationHandler
    {
        public override string Handle(object model)
        {
            if (model is Band band)
            {
                if (string.IsNullOrWhiteSpace(band.Name))
                    return "Название группы не может быть пустым";
                if (band.Name.Length < 2)
                    return "Название группы слишком короткое";
            }
            return _next?.Handle(model);
        }
    }

    public class BandGenreValidator : ValidationHandler
    {
        public override string Handle(object model)
        {
            if (model is Band band)
            {
                if (string.IsNullOrWhiteSpace(band.Genre))
                    return "Жанр группы не указан";
            }
            return _next?.Handle(model);
        }
    }

    public class MemberNameValidator : ValidationHandler
    {
        public override string Handle(object model)
        {
            if (model is Member member)
            {
                if (string.IsNullOrWhiteSpace(member.FullName))
                    return "Имя участника не может быть пустым";
                if (member.FullName.Length < 2)
                    return "Имя участника слишком короткое";
            }
            return _next?.Handle(model);
        }
    }

    public class MemberRoleValidator : ValidationHandler
    {
        public override string Handle(object model)
        {
            if (model is Member member)
            {
                if (string.IsNullOrWhiteSpace(member.Role))
                    return "Роль участника не указана";
            }
            return _next?.Handle(model);
        }
    }
}