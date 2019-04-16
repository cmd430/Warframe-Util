const tabletojson = require('tabletojson')
const fs = require('fs')

tabletojson.convertUrl('https://warframe.fandom.com/wiki/Warframes_Comparison/Stats', {
    useFirstRowForHeadings: true
  },
  function(tablesAsJson) {
    let rank_multipliers = {
      armor: 1,
      health: 3,
      shield: 3,
      energy: 1.5,
      strength: 1
    }
    let unranked = tablesAsJson[0]
    let rank30 = tablesAsJson[1]
    let warframes = {}
    unranked.forEach((warframe, index) => {
      if(!warframe.Name.includes(' Umbra Prime')) {
        warframe.Armor = (warframe.Armor === "-" ? 0 : warframe.Armor)
        warframe.Health = (warframe.Health === "-" ? 0 : warframe.Health)
        warframe.Shields = (warframe.Shields === "-" ? 0 : warframe.Shields)
        warframe.Energy = (warframe.Energy === "-" ? 0 : warframe.Energy)
        if (warframe.Name.includes(' Prime')) {
          warframes[warframe.Name.toLowerCase().replace(' prime', '')].variants.prime = {
            "armor": +warframe.Armor,
            "health": +warframe.Health,
            "shield": +warframe.Shields,
            "energy": +warframe.Energy,
            "strength": 100
          }
        } else if (warframe.Name.includes(' Umbra')) {
          warframes[warframe.Name.toLowerCase().replace(' umbra', '')].variants.umbra = {
            "armor": +warframe.Armor,
            "health": +warframe.Health,
            "shield": +warframe.Shields,
            "energy": +warframe.Energy,
            "strength": 100
          }
        } else {
          warframes[warframe.Name.toLowerCase()] = {}
          warframes[warframe.Name.toLowerCase()].variants = {}
          warframes[warframe.Name.toLowerCase()].variants.base = {
            "armor": +warframe.Armor,
            "health": +warframe.Health,
            "shield": +warframe.Shields,
            "energy": +warframe.Energy,
            "strength": 100
          }
          let overrides = {
            rank_multipliers: {}
          }
          let armor = (rank30[index].Armor / warframe.Armor === rank_multipliers.armor ? null : rank30[index].Armor / warframe.Armor)
          let health = (rank30[index].Health / warframe.Health === rank_multipliers.health ? null : rank30[index].Health / warframe.Health)
          let shield = (rank30[index].Shields / warframe.Shields === rank_multipliers.shield ? null : rank30[index].Shields / warframe.Shields)
          let energy = (rank30[index].Energy / warframe.Energy === rank_multipliers.energy ? null : rank30[index].Energy / warframe.Energy)
          let strength
          switch (warframe.Name.toLowerCase()) {
            case "nidus":
              strength = 1.15
              break;
            default:
              strength = null
          }
          if (armor !== null && !isNaN(armor)) {
            overrides.rank_multipliers.armor = armor
          }
          if (health !== null && !isNaN(health)) {
            overrides.rank_multipliers.health = health
          }
          if (shield !== null && !isNaN(shield)) {
            overrides.rank_multipliers.shield = shield
          }
          if (energy !== null && !isNaN(energy)) {
            overrides.rank_multipliers.energy = energy
          }
          if (strength !== null && !isNaN(strength)) {
            overrides.rank_multipliers.strength = strength
          }
          if (Object.keys(overrides.rank_multipliers).length !== 0) {
            warframes[warframe.Name.toLowerCase()].overrides = overrides
          }
        }
      }
    })
    Object.keys(warframes).forEach(warframe => {
      Promise.all([
        new Promise((resolve, reject) => {
          fs.access('abilities/' + warframe + '.json', fs.F_OK, err => {
            if (!err) {
              warframes[warframe].abilities = require('./abilities/' + warframe + '.json')
            }
            return resolve()
          })
        }),
        new Promise((resolve, reject) => {
          fs.access('overrides/' + warframe + '.json', fs.F_OK, err => {
            if (!err) {
              warframes[warframe].overrides = Object.assign({}, warframes[warframe].overrides, require('./overrides/' + warframe + '.json'))
            }
            return resolve()
          })
        })
      ])
      .then(() => {
        if (warframe !== "name") {
          fs.mkdir('warframes/', err => {})
          fs.writeFile('warframes/' + warframe + '.json', JSON.stringify(warframes[warframe], null, 2), err => {
            if (err) {
              return Promise.reject(err)
            }
          })
        }
      })
      .catch(err => {
        console.error(err)
      })
    })
  }
)