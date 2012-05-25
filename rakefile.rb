require 'rubygems'
require 'rake/clean'
require 'albacore'

WORKING_DIR = File.dirname(__FILE__)

ARTIFACTS = "artifacts"
PRODUCT = "FubuMvcApp"
SRC_DIR = "src"

# Add directories to Rake's clean task
CLEAN.include(ARTIFACTS)

desc "Displays a list of tasks"
task :help do
  taskHash = Hash[*(`rake.bat -T`.split(/\n/).collect { |l| l.match(/rake (\S+)\s+\#\s(.+)/).to_a }.collect { |l| [l[1], l[2]] }).flatten]

  indent = " " * 26

  puts "rake #{indent}#Runs the 'default' task"

  taskHash.each_pair do |key, value|
    if key.nil?
      next
    end
    puts "rake #{key}#{indent.slice(0, indent.length - key.length)}##{value}"
  end
end

desc "**Default**, packaging of the vs project template"
task :default => [:package]

desc "ZIPs up the build results"
task :package do
        mkdir_p ARTIFACTS
        zip = ZipDirectory.new
        zip.directories_to_zip = 'src'
        zip.output_file = 'FubuMvcApp.zip'
        zip.output_path = [ARTIFACTS]
        zip.execute
end



