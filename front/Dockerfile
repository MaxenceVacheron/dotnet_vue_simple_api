FROM node:10-alpine

WORKDIR /usr/src/app

COPY . .

# RUN npm install webpack-dev-server -g
# RUN npm install webpack
RUN npm install webpack@^4.0.0 --save-dev
RUN npm install
# RUN npm update

# ENTRYPOINT [ "npm", "run", "serve" ]