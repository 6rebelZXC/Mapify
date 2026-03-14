import { REST, Routes } from 'discord.js';
import TEST from './authds.json' with {"type": "json"};
import fs from "fs"
const {tokends} = TEST;
const CLIENT_ID = "1482073842724896959";
import functions from './fs.js';

// 
//


const commands = [
  {
    name: 'ping',
    description: 'Replies with Pong!',
  },
];

const rest = new REST({ version: '10' }).setToken(tokends);

try {
  console.log('Started refreshing application (/) commands.');

  await rest.put(Routes.applicationCommands(CLIENT_ID), { body: commands });

  console.log('Successfully reloaded application (/) commands.');
} catch (error) {
  console.error(error);
}

import { Client, Events, GatewayIntentBits } from 'discord.js';
const client = new Client({ intents: [GatewayIntentBits.Guilds] })
// Client form and / commands
functions(client);
export default client;

client.on(Events.ClientReady, readyClient => {
  console.log(`Logged in as ${readyClient.user.tag}!`);
});

client.on(Events.InteractionCreate, async interaction => {
  if (!interaction.isChatInputCommand()) return;

  if (interaction.commandName === 'ping') {
    await interaction.reply('Pong!');
  }
});

client.login(tokends);

