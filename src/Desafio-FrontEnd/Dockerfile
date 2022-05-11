### MULTI STAGE BUILD

# STAGE 1
FROM node:latest as ng-builder
RUN mkdir -p /app
WORKDIR /app
COPY package.json /app
RUN npm install --legacy-peer-deps
COPY . /app
RUN $(npm bin)/ng build --prod


# Stage 2
FROM nginx
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=ng-builder /app/dist/desafio-front-end /usr/share/nginx/html

EXPOSE 80
