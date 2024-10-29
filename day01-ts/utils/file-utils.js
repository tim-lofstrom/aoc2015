"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.readInputLines = readInputLines;
exports.readInputLine = readInputLine;
var fs = require("fs");
var path = require("path");
function readInputLines(dir, file) {
    var filePath = path.join(dir, file);
    return fs.readFileSync(filePath, "utf-8").split("\n");
}
function readInputLine(dir, file) {
    var filePath = path.join(dir, file);
    return fs.readFileSync(filePath, "utf-8");
}
