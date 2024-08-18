FROM node
WORKDIR /app
COPY . .
RUN npm install -g @angular/cli
RUN npm install
RUN npm update
EXPOSE 7777:4200
CMD ["ng", "serve", "--host", "0.0.0.0"]