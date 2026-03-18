import { Client, Collection, Events, GatewayIntentBits, MessageFlags } from 'discord.js';
import TOKEN from './authds.json' with {"type": "json"};
// import request from 'request';

import fs from 'fs';
import { fileURLToPath } from 'url';
import {dirname} from 'path';
import path from 'path';


// Dz
const {tokends} = TOKEN;
const CLIENT_ID = "1482073842724896959";
const client = new Client({ intents: [GatewayIntentBits.Guilds] });
const __dirname = dirname(fileURLToPath(import.meta.url));

export default client;
// Dzend



// Filesystem (fs)

client.commands = new Collection();

// commands

const foldersPathCmds = path.join(__dirname, 'cmds');
const commandFoldersCmds = fs.readdirSync(foldersPathCmds);

(async () => {
  for (const folder of commandFoldersCmds) {
    const commandsPath = path.join(foldersPathCmds, folder);
    const commandFiles = fs.readdirSync(commandsPath).filter(file => file.endsWith('.js'));

    for (const file of commandFiles) {
      const filePath = path.join(commandsPath, file);

      const commandModule = await import(`file://${filePath}`);
      const command = commandModule.default ?? commandModule;

      if ('data' in command && 'execute' in command) {
        client.commands.set(command.data.name, command);
      } else {
        console.log(`[WARNING] The command at ${filePath} is missing a required "data" or "execute" property.`);
      }
    }
  }
})();

// Events

const eventsPath = path.join(__dirname, 'Events');
const eventFiles = fs.readdirSync(eventsPath).filter(file => file.endsWith('.js'));

(async () => {
  for (const file of eventFiles) {
    const filePath = path.join(eventsPath, file);

    const eventModule = await import(`file://${filePath}`);
  }
})();
// Fsend


// Eventsend

client.login(tokends);

import { REST, Routes } from 'discord.js';

import cmdss from './lists/commands.json' with {"type": "json"}
const commands = cmdss;

const rest = new REST({ version: '10' }).setToken(tokends);


try {
  console.log('Started refreshing application (/) commands.');

  await rest.put(Routes.applicationCommands(CLIENT_ID), { body: commands });

  console.log('Successfully reloaded application (/) commands.');
} catch (error) {
  console.error(error);
}


