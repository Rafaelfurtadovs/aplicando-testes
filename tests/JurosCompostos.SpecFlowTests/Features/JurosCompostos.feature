# language: pt-BR
Funcionalidade: Calculo de juros compostos
  Como usuario da calculadora financeira
  Quero calcular o montante final com juros compostos
  Para validar o resultado esperado ao final do periodo

Cenario: Calcular investimento com taxa mensal de um por cento
  Dado que o valor inicial e 1000
  E que a taxa mensal e 1
  Quando calcular os juros por 12 meses
  Entao o montante final deve ser 1126.83

Cenario: Calcular investimento com taxa mensal de dois por cento
  Dado que o valor inicial e 1500
  E que a taxa mensal e 2
  Quando calcular os juros por 6 meses
  Entao o montante final deve ser 1689.24
