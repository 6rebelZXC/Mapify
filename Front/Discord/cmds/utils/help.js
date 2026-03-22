import fs from 'fs';
import { SlashCommandBuilder } from '@discordjs/builders';

export default {
    data: new SlashCommandBuilder()
    .setName('help')
    .setDescription('Lists all available commands'),
    async execute(interaction) {
        let str
        const commandFiles = fs.readdirSync('./cmds/utils').filter(file => file.endsWith('.js'));

        for (const file of commandFiles) {
        const command = require(`./${file}`);
        str += `Name: ${command.data.name}, Description: ${command.data.description} \n`;
        }

        return interaction.reply({
        content: str,
        ephemeral: true,
        });
    },
};