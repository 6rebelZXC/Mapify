import Discord, {ActivityType} from 'discord.js'
import { Events, Routes } from 'discord.js';
import client from '../index.js'
import chalk from 'chalk'
client.on(Events.InteractionCreate, async interaction => {
  if (!interaction.isChatInputCommand()) return;
  console.log("{Event:Interaction} Ready")
  if (interaction.commandName === 'ping') {
    await interaction.reply('Pong!');
  }
  // TODO: Убрать НАХУЙ отсюда ебаные команды
});
