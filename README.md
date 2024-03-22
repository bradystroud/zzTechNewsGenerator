# SSW Tech News Generator

[![.NET](https://github.com/bradystroud/TechNewsGenerator/actions/workflows/dotnet.yml/badge.svg)](https://github.com/bradystroud/TechNewsGenerator/actions/workflows/dotnet.yml)

This is a POC to see if AI could do a good job at generating tech news. I'm not convinced it can yet, but I'll continue
to work on the prompt.

## F5 Instructions

`dotnet run` 🤯

## POC Results

There are a few steps to manually preparing the news:

1. Find articles - usually done by browsing Microsoft, GitHub, OpenAI, and other blogs.
2. Picking the most important ones - done by reading the articles and understanding the content.
2. Add notes for the presenter - done by reading and understanding articles, and finding the most important bits. Also
   add why it matters

| Step                            | Can it be automated? 🤖                                                                                                                            |
|---------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------|
| 1. Get the articles             | Yes, using RSS feeds seems to be working ok.                                                                                                       |
| 2. Pick the most important ones | I'm using OpenAI API to do this but I feel this will always need manual help (e.g. Generate initial list with AI then human with add/remove links) |
| 3. Add notes for the presenter  | Not yet tested, but should be doable with AI                                                                                                       |

Overall, I am not convinced that this can be automated well.

### Example output from app:

```md
1. GitHub Copilot Learning Pathway: Accelerate your business with
   AI - https://github.blog/2024-03-04-github-copilot-learning-pathway-accelerate-your-business-with-ai/
2. GitHub Enterprise Server 3.12 is now generally
   available - https://github.blog/2024-03-06-github-enterprise-server-3-12-is-now-generally-available/
3. How GitHub uses merge queue to ship hundreds of changes every
   day - https://github.blog/2024-03-06-how-github-uses-merge-queue-to-ship-hundreds-of-changes-every-day/
4. Hard and soft skills for developers coding in the age of
   AI - https://github.blog/2024-03-07-hard-and-soft-skills-for-developers-coding-in-the-age-of-ai/
5. Review completed & Altman, Brockman to continue to lead
   OpenAI - https://openai.com/blog/review-completed-altman-brockman-to-continue-to-lead-openai
6. OpenAI announces new members to board of
   directors - https://openai.com/blog/openai-announces-new-members-to-board-of-directors
7. Found means fixed: Introducing code scanning autofix, powered by GitHub Copilot and
   CodeQL - https://github.blog/2024-03-20-found-means-fixed-introducing-code-scanning-autofix-powered-by-github-copilot-and-codeql/
8. Announcing SQL Server Data Tools (SSDT) for ARM64 Architecture in Visual Studio 17.10 Preview
   2 - https://devblogs.microsoft.com/visualstudio/arm64-in-ssdt
9. Introducing .NET Smart Components – AI-powered UI
   controls - https://devblogs.microsoft.com/dotnet/introducing-dotnet-smart-components
10. Teams Toolkit for Visual Studio Code update – March
    2024 - https://devblogs.microsoft.com/microsoft365dev/teams-toolkit-for-visual-studio-code-update-march-2024
11. Insider newsletter digest: 4 things you didn’t know you could do with GitHub
    Projects - https://github.blog/2024-03-21-insider-newsletter-digest-4-things-you-didnt-know-you-could-do-with-github-projects/
12. Image to Text with Semantic Kernel and
    HuggingFace - https://devblogs.microsoft.com/semantic-kernel/image-to-text-with-semantic-kernel-and-huggingface
13. APIs load testing using K6 - https://devblogs.microsoft.com/ise/apis-load-testing-using-k6
14. Introducing Regular Expression (Regex) Support in Azure SQL
    DB - https://devblogs.microsoft.com/azure-sql/introducing-regular-expression-regex-support-in-azure-sql-db
```