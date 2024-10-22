pipeline {
    agent any

    triggers {
        pollSCM('* * * * *')
    }

    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:8.0'
        }
    }

    stages {
     
        stage('Verify .NET Installation') {
            steps {
                sh 'dotnet --version'
            }
        }
        stage('Build') {
            steps {
                echo 'Building..'
                sh "dotnet build LoggingApi.csproj"
            }
        } 
        stage('Test') {
            steps { 
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }  
}