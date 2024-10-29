"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var lodash_1 = require("lodash");
var file_utils_1 = require("./utils/file-utils");
var input = (0, file_utils_1.readInputLine)(__dirname, "input.txt");
var parts = (0, lodash_1.split)(input, "");
function calcNextFloor(floor, direction) {
    switch (direction) {
        case "(":
            return floor + 1;
        case ")":
            return floor - 1;
        default:
            return floor;
    }
}
function basement(parts, floor) {
    if (floor === -1)
        return 0;
    var direction = (0, lodash_1.first)(parts);
    var rest = (0, lodash_1.tail)(parts);
    var nextFloor = calcNextFloor(floor, direction);
    return 1 + basement(rest, nextFloor);
}
var part1 = (0, lodash_1.reduce)(parts, function (floor, direction) { return calcNextFloor(floor, direction); }, 0);
var part2 = basement(parts, 0);
console.log(part1);
console.log(part2);
