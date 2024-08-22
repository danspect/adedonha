#!usr/bin/env python
# Copyright (c) 2023 Daniel Aspect
#
# Permission is hereby granted, free of charge, to any person obtaining a copy
# of this software and associated documentation files (the "Software"), to deal
# in the Software without restriction, including without limitation the rights
# to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
# copies of the Software, and to permit persons to whom the Software is
# furnished to do so, subject to the following conditions:
#
# The above copyright notice and this permission notice shall be included in all
# copies or substantial portions of the Software.
#
# THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
# IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
# FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
# AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
# LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
# OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
# SOFTWARE.
import random


temas: list = [
    "profissões",
    "animais",
    "cidades",
    "estado",
    "paises",
    "comidas",
    "cores",
    "marcas",
    "carros",
    "planetas",
    "personagens",
    "filmes",
    "series",
    "partes do corpo",
    "Atores",
    "comidas em ingles",
    "cores em ingles"
]

alfabeto: list = list("ABCDEFGHIJKLMNOPQRSTUVWXYZ")


def escolher_letra(alfabeto: list):
    return alfabeto[random.randint(0, len(alfabeto) - 1)]


def escolher_tema(temas: list):
    return temas[random.randint(0, len(temas) - 1)]


print(f"Tema: {escolher_tema(temas)}\nLetra: {escolher_letra(alfabeto)}")
