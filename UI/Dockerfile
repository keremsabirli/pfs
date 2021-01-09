# FROM nginx

# RUN rm /etc/nginx/conf.d/default.conf

# COPY ./nginx/config/nginx.conf /etc/nginx/conf.d/default.conf


FROM node:latest as build
WORKDIR /app
COPY package.json package.json
RUN npm install
COPY . .
RUN npm run build -- --prod
FROM nginx
COPY --from=build /app/dist/ /usr/share/nginx/html
# Copy the default nginx.conf provided by tiangolo/node-frontend
RUN rm /etc/nginx/conf.d/default.conf

COPY nginx.conf /etc/nginx/conf.d/default.conf
