require 'rubygems'
require 'rake/clean'
require 'albacore'

WORKING_DIR = File.dirname(__FILE__)

ARTIFACTS = "artifacts"
PRODUCT = "FubuMvcApp"
SRC_DIR = "src"
VSIX = "vsix"

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
task :default => [:package, :vsix]

desc "ZIPs up the build results"
task :package do
        mkdir_p ARTIFACTS
        zip = ZipDirectory.new
        zip.directories_to_zip = 'src'
        zip.output_file = 'FubuMvcApp.zip'
        zip.output_path = [ARTIFACTS]
        zip.execute
end

desc "Creates the VSIX package"
task :vsix do
        mkdir_p VSIX
        #copy the FubuMvcApp.zip to the vsix\ProjectTemplates\CSharp\Web folder
		copy(File.join([ARTIFACTS], 'FubuMvcApp.zip'), 'vsix/ProjectTemplates/CSharp/Web')
		zip = ZipDirectory.new
        zip.directories_to_zip = VSIX
        zip.output_file = 'FubuMvcApp.vsix'
        zip.output_path = [ARTIFACTS]
        zip.execute
end



