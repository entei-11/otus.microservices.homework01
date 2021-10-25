# otus.microservices.homework01

## Домашнее задание "Основы работы с Kubernetes (часть 2)"

### Цель: В этом ДЗ вы научитесь создавать минимальный сервис.

1. Создать минимальный сервис, который:
- отвечает на порту 8000
- имеет http-метод GET /health/ RESPONSE: {"status": "OK"}

2. Cобрать локально образ приложения в докер.

3. Запушить образ в dockerhub

4. Написать манифесты для деплоя в k8s для этого сервиса.

- Манифесты должны описывать сущности Deployment, Service, Ingress.
- В Deployment могут быть указаны Liveness, Readiness пробы.
- Количество реплик должно быть не меньше 2.
- Image контейнера должен быть указан с Dockerhub.
- Хост в ингрессе должен быть arch.homework. В итоге после применения манифестов GET запрос на http://arch.homework/health должен отдавать `{"status": "OK"}`.
- На выходе предоставить ссылку на github c манифестами. Манифесты должны лежать в одной директории, так чтобы можно было их все применить одной командой `kubectl apply -f .`

### Результат

1. Минимальный сервис отвечает на 8000 порту (на самом деле на любом, это можно настроить через переменную окружения ASPNETCORE_URLS)

2. Образ локально собирается через студию или команду в рабочей папке проекта с докер файлом (Otus.Microservices.Homework01.WebApi.Host):
```bash
cd ./Otus.Microservices.Homework01.WebApi.Host
docker build -f Dockerfile  ..
```

3. Образ опубликован в [entei11/otus.microservices.homework01.webapi:latest](https://registry.hub.docker.com/r/entei11/otus.microservices.homework01.webapi/tags)

4. Манифесты для деплоя сервиса в k8s лежат в [Otus.Microservices.Homework01.K8s](./Otus.Microservices.Homework01.K8s)