using System;

public class EmailJaCadastradoException : Exception
{
    public EmailJaCadastradoException() : base("Email já cadastrado.") { }
}

public class CpfCnpjJaCadastradoException : Exception
{
    public CpfCnpjJaCadastradoException() : base("CPF ou CNPJ já cadastrado.") { }
}

public class CpfCnpjInvalidoException : Exception
{
    public CpfCnpjInvalidoException() : base("CPF ou CNPJ inválido.") { }
}

public class CampoObrigatorioException : Exception
{
    public CampoObrigatorioException(string campo) : base($"O campo '{campo}' é obrigatório.") { }
}

public class EstadoNaoPertenceAoPaisException : Exception
{
    public EstadoNaoPertenceAoPaisException() : base("Estado não pertence ao país") { }
}

public class CidadeNaoPertenceAoEstadoException : Exception
{
    public CidadeNaoPertenceAoEstadoException() : base("Cidade não pertence ao estado") { }
}

public class SenhaDeveConterNoMinimo8CaracteresException : Exception
{
    public SenhaDeveConterNoMinimo8CaracteresException() : base("A senha deve conter no mínimo 8 caracteres") { }
}

public class SenhaDeveConterRegexMatchException : Exception
{
    public SenhaDeveConterRegexMatchException() : base("A senha deve conter pelo menos uma letra maiúscula, uma minúscula, um número e um caractere especial") { }
}
