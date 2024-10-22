pipeline {
    agent any

    triggers {
        pollSCM('* * * * *')
    }


    stages {
        stage('Install .NET SDK') {
            steps {
                script {
                    sh '''
                    apt-get update &&
                    apt-get install -y wget apt-transport-https &&
                    wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb &&
                    dpkg -i packages-microsoft-prod.deb &&
                    apt-get update &&
                    apt-get install -y dotnet-sdk-8.0
                    '''
                }
            }
        }
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