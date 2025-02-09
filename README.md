# Number Guessing Game 

[![.NET Version](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/License-MIT-green)](LICENSE)

A pet project in C# from roadmap.sh

---

## Table of Contents
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [License](#license)
---

## Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download) (or newer)
- Terminal access (Bash, PowerShell, or Command Prompt)

---

## Installation

### 1. Clone the Repository
```bash
git clone https://github.com/Stefan-D-Dimitrov/roadmap-sh-number-guessing-game
cd ngg
```

### 2. Build the Executable
#### Linux/macOS
```bash
dotnet publish -c Release -r linux-x64 --self-contained true
```
#### Windows
```powershell
dotnet publish -c Release -r win-x64 --self-contained true
```
### 3. Add to System PATH
#### Linux/macOS
```bash
# System-wide install (requires sudo)
sudo mv Ngg /usr/local/bin/

# OR user-specific install
mkdir -p ~/bin && mv Ngg ~/bin/
echo 'export PATH="$HOME/bin:$PATH"' >> ~/.bashrc
source ~/.bashrc
```

#### Windows
1. Add a custom directory (e.g., `C:\MyApps`) to your [system PATH](https://learn.microsoft.com/en-us/windows/win32/procthread/environment-variables).

---

## Usage
Run the tool directly from any terminal:
```bash
Ngg 
```
---

## License
Distributed under the MIT License. See [LICENSE](LICENSE) for details.

---
