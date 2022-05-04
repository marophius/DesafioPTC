FROM node:lts-alpine as Desafio.FrontEnd
ENV NODE_ENV=production
WORKDIR /usr/src/app
COPY ["package.json", "/app"]
RUN npm install
COPY . .
EXPOSE 3000
RUN chown -R node /usr/src/app
USER node
CMD ["npm", "start"]
