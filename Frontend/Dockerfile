FROM node:21-alpine3.18 AS base

USER node
WORKDIR /app

FROM base AS builder

COPY --chown=node:node package*.json ./

RUN --mount=type=cache,uid=1000,gid=1000,target=/home/node/.npm/ npm i

COPY . ./

RUN npm run build

FROM base AS runner

COPY package.json ./
COPY --chown=root:root --from=builder /app/build /app/build

CMD ["npm", "start"]
